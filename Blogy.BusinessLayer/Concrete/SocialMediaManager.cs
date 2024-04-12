using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
	public class SocialMediaManager : ISocialMediaService
	{
		private readonly ISocialMediaDal _socialMediaDal;

		public SocialMediaManager(ISocialMediaDal socialMediaDal)
		{
			_socialMediaDal = socialMediaDal;
		}

		public void TAdd(SocialMedia entity)
		{
			_socialMediaDal.Insert(entity);
		}

		public List<SocialMedia> TGetAllList()
		{
			return _socialMediaDal.GetListAll();
		}

		public SocialMedia TGetById(int id)
		{
			return _socialMediaDal.GetById(id);
		}

		public void TRemove(int id)
		{
			_socialMediaDal.Remove(id);
		}

		public void TUpdate(SocialMedia entity)
		{
			_socialMediaDal.Update(entity);
		}
	}
}
