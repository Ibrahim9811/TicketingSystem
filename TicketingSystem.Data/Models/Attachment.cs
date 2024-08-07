using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Data.Models
{
    public class Attachment
    {
        public Guid AttachmentId { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
