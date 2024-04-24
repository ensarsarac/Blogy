using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.CommentDtos
{
	public class CommentListByUserIdDto
	{
        public int CommentId { get; set; }
        public string ArticleTitle { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string UserNameSurname { get; set; }
        public string UserImageUrl { get; set; }
    }
}
