using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.CategoryDtos
{
    public class CategoryNameAndCountDto
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
