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
	public class SendMessageManager : ISendMessageService
	{
		private readonly ISendMessageDal _sendMessageDal;

		public SendMessageManager(ISendMessageDal sendMessageDal)
		{
			_sendMessageDal = sendMessageDal;
		}

		public void TAdd(SendMessage entity)
		{
			_sendMessageDal.Insert(entity);
		}

		public List<SendMessage> TGetAllList()
		{
			return _sendMessageDal.GetListAll();
		}

		public SendMessage TGetById(int id)
		{
			return _sendMessageDal.GetById(id);
		}

		public List<SendMessage> TGetListOrderBy()
		{
			return _sendMessageDal.GetListOrderBy();
		}

		public void TRemove(int id)
		{
			_sendMessageDal.Remove(id);
		}

		public void TUpdate(SendMessage entity)
		{
			_sendMessageDal.Update(entity);
		}
	}
}
