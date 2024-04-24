using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.NotificationDtos
{
    public class GetNotificationDto
    {
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}
