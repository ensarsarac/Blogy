using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concrete
{
    public class Writer
    {
        public int WriterID { get; set; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        public string ImageUrl{ get; set; }
        public List<Article> Articles{ get; set; }
    }
}
