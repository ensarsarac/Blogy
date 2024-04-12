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
    public class EfCommentRepository:GenericUowRepository<Comment>,ICommentDal
    {
        private readonly BlogyContext _context;
        public EfCommentRepository(BlogyContext context) : base(context)
        {
            _context = context;
        }

        public List<Comment> GetCommentListWithUser(int id)
        {
            var values = _context.Comments.Where(x => x.ArticleID == id).Include(y => y.AppUser).ToList();
            return values;
        }
    }
}
