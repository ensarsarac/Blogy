using Blogy.BusinessLayer.ErrorMessages;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Container
{
	public static class IdentityDependency
	{
		public static void IdentityDependencyContainer(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddIdentity<AppUser, AppRole>(opt =>
			{
				opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				opt.User.RequireUniqueEmail = true;
				opt.SignIn.RequireConfirmedEmail = true;
			}).AddEntityFrameworkStores<BlogyContext>().AddDefaultTokenProviders().AddErrorDescriber<CustomIdentityValidator>();
		}
	}
}
