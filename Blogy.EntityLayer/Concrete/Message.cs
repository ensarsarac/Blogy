using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concrete
{
    public class Message
    {
        public int MessageId { get; set; }
        public int ReceiverUserId { get; set; }
        public AppUser ReceiverUser { get; set; }
        public int SenderUserId { get; set; }
        public AppUser SenderUser { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
    }
}
