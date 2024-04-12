using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.ArticleDtos
{
    public class Last3BlogDto
    {
		public int ArticleID { get; set; }
		public string CoverImageUrl { get; set; }
		public string Title{ get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
