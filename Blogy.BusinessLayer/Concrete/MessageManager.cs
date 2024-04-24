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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public List<Message> TGetAllList()
        {
            return _messageDal.GetListAll();
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetLast3MessageListByUserId(int userId)
        {
            return _messageDal.GetLast3MessageListByUserId(userId);
        }

        public List<Message> TGetMessageListByUserId(int userId)
        {
            return _messageDal.GetMessageListByUserId(userId);
        }

        public void TRemove(int id)
        {
            _messageDal.Remove(id);
        }

        public void TUpdate(Message entity)
        {
           _messageDal.Update(entity);
        }
    }
}
