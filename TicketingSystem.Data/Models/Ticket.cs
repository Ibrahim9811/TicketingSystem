using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Data.Models
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }

    public enum TicketStatus
    {
        New = 0,
        Pending = 1,
        Closed = 2,
    }
}
