using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.ArticleDtos
{
	public class GetArticleByUserIdDto
	{
		public int ArticleId { get; set; }
		public string Title { get; set; }
		public string NameSurname { get; set; }
		public string UserImageUrl { get; set; }
		public DateTime Date { get; set; }
		public string CategoryName { get; set; }
	}
}
