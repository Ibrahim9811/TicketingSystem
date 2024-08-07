using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data.Models;
using TicketingSystem.Services.DTOs;

namespace TicketingSystem.Data.IServices
{
    public interface IAuth
    {
        Task<AuthDTO> GetTokenAsync(LoginDTO model);
        Task<User?> FindByPhoneNumberAsync(string PhoneNumber);
    }
}
