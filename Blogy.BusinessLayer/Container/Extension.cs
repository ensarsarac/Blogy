using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.DataAccessLayer.UnitOfWork;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Container
{
	public static class Extension
	{
        public static void AddServices(this IServiceCollection services)
        {
			services.AddScoped<ICategoryDal, EfCategoryRepository>();
			services.AddScoped<ICategoryService, CategoryManager>();
			services.AddScoped<IArticleDal, EfArticleRepository>();
			services.AddScoped<IArticleService, ArticleManager>();
			services.AddScoped<ITagService, TagManager>();
			services.AddScoped<ITagDal, EfTagRepository>();
			services.AddScoped<IContactService, ContactManager>();
			services.AddScoped<IContactDal, EfContactRepository>();
			services.AddScoped<ISendMessageDal, EfSendMessageRepository>();
			services.AddScoped<ISendMessageService, SendMessageManager>();
			services.AddScoped<ICommentDal, EfCommentRepository>();
			services.AddScoped<ICommentService,CommentManager>();
			services.AddScoped<ICommentService,CommentManager>();
			services.AddScoped<IUowDal,UowDal>();
			services.AddScoped<IAboutDal,EfAboutRepository>();
			services.AddScoped<IAboutService,AboutManager>();
			services.AddScoped<ISocialMediaDal,EfSocialMediaRepository>();
			services.AddScoped<ISocialMediaService,SocialMediaManager>();
			services.AddScoped<IAppUserDal,EfAppUserRepository>();
			services.AddScoped<IAppUserService,AppUserManager>();
			services.AddScoped<IAppRoleDal,EfAppRoleRepository>();
			services.AddScoped<IAppRoleService,AppRoleManager>();
			services.AddScoped<IMessageService,MessageManager>();
			services.AddScoped<IMessageDal,EfMessageRepository>();
			services.AddScoped<INotificationService,NotificationManager>();
			services.AddScoped<INotificationDal,EfNotificationRepository>();

			services.AddControllersWithViews().AddFluentValidation(opt =>
			{
				opt.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");
			});
		}
    }
}
