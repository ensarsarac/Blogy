using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
	public class ContactManager : IContactService
	{
		private readonly IContactDal _contactDal;

		public ContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}

		public void TAdd(ContactInfo entity)
		{
			_contactDal.Insert(entity);
		}

		public List<ContactInfo> TGetAllList()
		{
			return _contactDal.GetListAll();
		}

		public ContactInfo TGetById(int id)
		{
			return _contactDal.GetById(id);
		}

		public void TRemove(int id)
		{
			_contactDal.Remove(id);
		}

		public void TUpdate(ContactInfo entity)
		{
			_contactDal.Update(entity);
		}
	}
}
