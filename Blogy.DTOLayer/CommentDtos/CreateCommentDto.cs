using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.CommentDtos
{
    public class CreateCommentDto
    {
        public string Message { get; set; }
        public int ArticleID { get; set; }
    }
}
