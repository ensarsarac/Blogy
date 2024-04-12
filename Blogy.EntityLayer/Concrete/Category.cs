using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public List<Article> Articles{ get; set; }
    }
}
