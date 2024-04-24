using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
    public class EfMessageRepository : GenericRepository<Message>, IMessageDal
    {
        private readonly BlogyContext _context;
        public EfMessageRepository(BlogyContext context):base(context)
        {
            _context = context;
        }

        public List<Message> GetLast3MessageListByUserId(int userId)
        {
            var values = _context.Messages.Where(x=>x.ReceiverUserId == userId).Include(y=>y.SenderUser).OrderByDescending(x=>x.Date).Take(3).ToList();
            return values;
        }

        public List<Message> GetMessageListByUserId(int userId)
        {
            var values = _context.Messages.Where(x => x.ReceiverUserId == userId).Include(y => y.SenderUser).OrderByDescending(x => x.Date).ToList();
            return values;
        }
    }
}
