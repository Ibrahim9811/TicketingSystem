using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Services.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string UserIdentifier { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
