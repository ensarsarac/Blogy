using Blogy.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.UnitOfWork
{
    public class UowDal : IUowDal
    {
        private readonly BlogyContext _context;

        public UowDal(BlogyContext context)
        {
            _context = context;
        }


		public void Save()
        {
            _context.SaveChanges();
        }
    }
}
