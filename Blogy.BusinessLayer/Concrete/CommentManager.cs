using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.UnitOfWork;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IUowDal _uowDal;

        public CommentManager(ICommentDal commentDal, IUowDal uowDal)
        {
            _commentDal = commentDal;
            _uowDal = uowDal;
        }

        public void TAdd(Comment entity)
        {
            _commentDal.Insert(entity);
            _uowDal.Save();
        }

        public List<Comment> TGetAllList()
        {
            return _commentDal.GetListAll();
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> TGetCommentListWithUser(int id)
        {
            return _commentDal.GetCommentListWithUser(id);
        }

        public void TRemove(int id)
        {
            _commentDal.Remove(id);
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}
