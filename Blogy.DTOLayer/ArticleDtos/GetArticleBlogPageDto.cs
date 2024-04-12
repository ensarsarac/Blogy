using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.ArticleDtos
{
    public class GetArticleBlogPageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public string CategoryName { get; set; }
        public DateTime Date { get; set; }
    }
}
