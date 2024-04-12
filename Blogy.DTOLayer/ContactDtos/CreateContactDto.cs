using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.ContactDtos
{
	public class CreateContactDto
	{
		public string Location { get; set; }
		public string OpenHours { get; set; }
		public string Email { get; set; }
		public string Call { get; set; }
	}
}
