using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate{ get; set; }
        public int ArticleID{ get; set; }
        public Article Article{ get; set; }
        public int? AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
