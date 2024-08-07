using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data.Models;

namespace TicketingSystem.Services.DTOs
{
    public class UserFiltersDTO
    {
        public Guid? RoleId { get; set; }
        public UserStatus? UserStatus { get; set; }
    }
}
