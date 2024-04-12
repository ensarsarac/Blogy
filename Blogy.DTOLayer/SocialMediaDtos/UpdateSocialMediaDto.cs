using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.SocialMediaDtos
{
	public class UpdateSocialMediaDto
	{
		public int SocialMediaID { get; set; }
		public string Platform { get; set; }
		public string Icon { get; set; }
		public string Url { get; set; }
	}
}
