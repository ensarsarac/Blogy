using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetListAll();
        T GetById(int id);
        void Insert(T entity);
        void Remove(int id);
        void Update(T entity);
    }
}
