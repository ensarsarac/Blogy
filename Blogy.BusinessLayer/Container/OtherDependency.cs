using AutoMapper;
using Blogy.BusinessLayer.Mapping;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Container
{
	public static class OtherDependency
	{
		public static void OtherDependencyContainer(this IServiceCollection services)
		{
			var automapper = new MapperConfiguration(x => x.AddProfile(new MapProfile()));
			IMapper mapper = automapper.CreateMapper();
			services.AddSingleton(mapper);

			
		}
	}
}
