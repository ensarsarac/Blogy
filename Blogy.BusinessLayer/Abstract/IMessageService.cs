using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        List<Message> TGetLast3MessageListByUserId(int userId);
        List<Message> TGetMessageListByUserId(int userId);
    }
}
