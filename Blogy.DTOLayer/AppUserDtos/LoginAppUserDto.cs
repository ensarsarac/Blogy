﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DTOLayer.AppUserDtos
{
	public class LoginAppUserDto
	{
        public string Email { get; set; }
		public string Password { get; set; }
    }
}
