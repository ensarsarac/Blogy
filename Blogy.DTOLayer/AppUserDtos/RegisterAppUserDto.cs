using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.AppUserDtos
{
	public class RegisterAppUserDto
	{
        public string Name { get; set; }
		public string Surname { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
        public bool Check { get; set; }
    }
}
