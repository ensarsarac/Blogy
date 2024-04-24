using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.MessageDtos
{
    public class GetMessatListDto
    {
        public int MessageId { get; set; }
        public string SenderUserName{ get; set; }
        public string SenderUserImageUrl{ get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
    }
}
