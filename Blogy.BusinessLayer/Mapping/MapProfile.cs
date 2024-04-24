using AutoMapper;
using Blogy.DTOLayer.AboutDtos;
using Blogy.DTOLayer.AppRoleDtos;
using Blogy.DTOLayer.AppUserDtos;
using Blogy.DTOLayer.ArticleDtos;
using Blogy.DTOLayer.CategoryDtos;
using Blogy.DTOLayer.CommentDtos;
using Blogy.DTOLayer.ContactDtos;
using Blogy.DTOLayer.SendMessageDtos;
using Blogy.DTOLayer.SocialMediaDtos;
using Blogy.DTOLayer.TagsDtos;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<GetTagDto, Tag>().ReverseMap();

            CreateMap<SendMessageDto, SendMessage>().ReverseMap();
            CreateMap<ResultSendMessageDto, SendMessage>().ReverseMap();

            CreateMap<GetCategoryList, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();

            CreateMap<ResultContactList, ContactInfo>().ReverseMap();
            CreateMap<CreateContactDto, ContactInfo>().ReverseMap();
            CreateMap<UpdateContactDto, ContactInfo>().ReverseMap();
            
            CreateMap<Last3BlogDto, Article>().ReverseMap();
            CreateMap<GetArticleByUserIdDto, Article>().ReverseMap();

            CreateMap<ResultSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<CreateSocialMediaDto, SocialMedia>().ReverseMap();

			CreateMap<ResultAboutDto, About>().ReverseMap();
			CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<ResultAppUserDto, AppUser>().ReverseMap();

            CreateMap<CreateAppRoleDto, AppRole>().ReverseMap();
            CreateMap<ResultAppRoleDto, AppRole>().ReverseMap();
            CreateMap<UpdateAppRoleDto, AppRole>().ReverseMap();
        }
    }
}
