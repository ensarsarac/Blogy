using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.CategoryDtos
{
	public class UpdateCategoryDto
	{
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="Boş bırakılamaz.")]
        public string Name { get; set; }
    }
}
