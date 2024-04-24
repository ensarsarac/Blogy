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
    public class AppRoleManager : IAppRoleService
    {
        private readonly IAppRoleDal _appRoleDal;

        public AppRoleManager(IAppRoleDal appRoleDal)
        {
            _appRoleDal = appRoleDal;
        }

        public void TAdd(AppRole entity)
        {
            _appRoleDal.Insert(entity);
        }

        public List<AppRole> TGetAllList()
        {
            return _appRoleDal.GetListAll();
        }

        public AppRole TGetById(int id)
        {
            return _appRoleDal.GetById(id);
        }

        public void TRemove(int id)
        {
            _appRoleDal.Remove(id);
        }

        public void TUpdate(AppRole entity)
        {
            _appRoleDal.Update(entity);
        }
    }
}
