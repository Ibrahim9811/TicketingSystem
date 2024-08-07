using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public string Address { get; set; }
        public UserImage UserImage { get; set; }
        public Guid ImgId { get; set; }
        public UserStatus Status { get; set; }
    }

    public enum UserStatus
    {
        Active = 1,
        Deactive = 0
    }
}
