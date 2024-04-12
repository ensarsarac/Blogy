using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.CommentDtos
{
    public class ResultCommentDto
    {
        public int CommentID { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string UserNameSurname { get; set; }
        public string UserImage { get; set; }
    }
}
