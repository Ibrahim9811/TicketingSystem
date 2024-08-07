using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using TicketingSystem.Data.IServices;
using TicketingSystem.Data.Models;
using TicketingSystem.Services.DTOs;
using TicketingSystem.Services.Helper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TicketingSystem.Services.Services
{
    public class Auth : IAuth
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly JWT _jwt;
        private readonly ApplicationDbContext _context = new();
        public Auth(UserManager<User> userManager, RoleManager<Role> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }

        public Task<User?> FindByPhoneNumberAsync(string PhoneNumber)
        {
            return _context.Users.Where(u => u.PhoneNumber == PhoneNumber).FirstOrDefaultAsync();
        }

        public async Task<AuthDTO> GetTokenAsync(LoginDTO model) 
        {
            var authModel = new AuthDTO();

            var user = await _userManager.FindByEmailAsync(model.UserIdentifier) ??
                       await _userManager.FindByNameAsync(model.UserIdentifier) ??
                       await FindByPhoneNumberAsync(model.UserIdentifier);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Credentials are incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.Message = "Login Successful!";
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Role = rolesList.FirstOrDefault();

            return authModel;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
