using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Data.Models
{

    public class UserImage
    {
        [Key]
        public Guid ImgId { get; set; }
        public string Path { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }

}
