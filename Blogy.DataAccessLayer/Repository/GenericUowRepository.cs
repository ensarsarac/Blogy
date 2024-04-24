using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Repository
{
    public class GenericUowRepository<T> : IGenericUowDal<T> where T : class
    {
        private readonly BlogyContext _context;

        public GenericUowRepository(BlogyContext context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
        }

        public void Remove(int id)
        {
            var value = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(value);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
