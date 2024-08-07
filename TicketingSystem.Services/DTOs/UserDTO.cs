using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data.Models;

namespace TicketingSystem.Services.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly Birthday { get; set; }
        public string Address { get; set; }
        public string Path { get; set; }
        public string Status { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
