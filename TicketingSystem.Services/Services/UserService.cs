using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Data.Models;
using TicketingSystem.Services.DTOs;
using TicketingSystem.Services.IServices;

namespace TicketingSystem.Services.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context = new();
        public async Task<IEnumerable<UserDTO>> GetUsersAsync(UserFiltersDTO Filters)
        {
            var usersIdsFilteredByRoleId = _context.UserRoles.Where(UR => (Filters.RoleId == null || UR.RoleId == Filters.RoleId)).Select(UR => UR.UserId);

            //return await _context.Users.Where(U => 
            //    (Filters.UserStatus == null || U.Status == Filters.UserStatus) &&
            //    (usersIdsFilteredByRoleId.Contains(U.Id))
            //).Select(U => new UserDTO
            //{
            //    Id = U.Id,
            //    UserName = U.UserName,
            //    FirstName = U.FirstName,
            //    LastName = U.LastName,
            //    Email = U.Email,
            //    PhoneNumber = U.PhoneNumber,
            //    Birthday = U.Birthday,
            //    Address = U.Address,
            //    Path = U.Path,
            //    Status = U.Status.ToString(),
            //    RoleId = _context.UserRoles.Where(UR => UR.UserId == U.Id).FirstOrDefault().RoleId,
            //    RoleName = _context.Roles.Where(R => R.Id == _context.UserRoles.Where(UR => UR.UserId == U.Id).FirstOrDefault().RoleId).FirstOrDefault().Name,
            //}).ToListAsync();

            return await (from user in _context.Users
                   join userRole in _context.UserRoles on user.Id equals userRole.UserId
                   join role in _context.Roles on userRole.RoleId equals role.Id
                   where (Filters.UserStatus == null || user.Status == Filters.UserStatus) &&
                         usersIdsFilteredByRoleId.Contains(user.Id)
                   select new UserDTO
                   {
                       Id = user.Id,
                       UserName = user.UserName,
                       FirstName = user.FirstName,
                       LastName = user.LastName,
                       Email = user.Email,
                       PhoneNumber = user.PhoneNumber,
                       Birthday = user.Birthday,
                       Address = user.Address,
                       Path = user.Path,
                       Status = user.Status.ToString(),
                       RoleId = role.Id,
                       RoleName = role.Name
                   }).ToListAsync();
        }

        public void SeedUsersTable()
        {
            var roles = new List<Guid> {
                new Guid("9c95394a-5c05-4ddd-b9e4-10b25c99861a"),
                new Guid("c8dad606-c313-4882-8d8b-67d7bd982f3e"),
                new Guid("c61d53ea-1655-4cb2-b529-63d80567d8fa")
            };

            for (int i = 0; i < 100; i++)
            {
                var UserGuid = Guid.NewGuid();
                var RoleGuid = roles.ElementAt(new Random().Next(0, 3));

                _context.Users.Add(new User
                {
                    Id = UserGuid,
                    FirstName = $"user#{i}",
                    LastName = "seeed",
                    Birthday = DateOnly.FromDateTime(DateTime.Now),
                    Address = "T2",
                    Path = "Test",
                    Status = i %2 == 0 ? UserStatus.Active : UserStatus.Deactive,
                    UserName = $"user#{i}",
                    NormalizedUserName = $"user#{i}",
                    Email = $"user{i}@test.com",
                    NormalizedEmail = $"user{i}@test.com",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher().HashPassword("P@ssword123"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "000000000",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = true,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                });
                _context.UserRoles.Add(new IdentityUserRole<Guid>
                {
                    RoleId = RoleGuid,
                    UserId = UserGuid,
                });
            }

            _context.SaveChangesAsync();
        }
    }
}
