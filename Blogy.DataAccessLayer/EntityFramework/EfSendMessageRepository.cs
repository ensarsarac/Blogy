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
	public class EfSendMessageRepository:GenericRepository<SendMessage>,ISendMessageDal
	{
		private readonly BlogyContext _context;
        public EfSendMessageRepository(BlogyContext context):base(context)
        {
			_context = context;
        }

		public List<SendMessage> GetListOrderBy()
		{
			return _context.SendMessages.OrderByDescending(x => x.SendMessageID).ToList();
		}
	}
}
