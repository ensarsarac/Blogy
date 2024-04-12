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
    public class TagManager:ITagService
    {
        private readonly ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public void TAdd(Tag entity)
        {
            _tagDal.Insert(entity);
        }

        public List<Tag> TGetAllList()
        {
            return _tagDal.GetListAll();
        }

        public Tag TGetById(int id)
        {
            return _tagDal.GetById(id);
        }

        public void TRemove(int id)
        {
            _tagDal.Remove(id);
        }

        public void TUpdate(Tag entity)
        {
            _tagDal.Update(entity);
        }
    }
}
