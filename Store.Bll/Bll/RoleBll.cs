using System.Collections.Generic;
using System.Linq;
using Store.Common;
using Store.Common.Helper;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IRoleBll : IBaseBll<Role>
    {
        new List<Role> GetAll();
    }

    public class RoleBll : BaseBll<Role, IRoleDal>, IRoleBll
    {
        protected IFactoryDal FactoryDal;

        public RoleBll(IFactoryDal factoryDal)
            : base(factoryDal.RoleDal)
        {
            FactoryDal = factoryDal;
        }

        public new List<Role> GetAll()
        {
            List<Role> result = CacheHelper.GetObjectFromCache<List<Role>>(GlobalConstants.RolesKey);
            if (result == null)
            {
                result = base.GetAll().ToList();
                CacheHelper.AddObjectToCache(GlobalConstants.RolesKey, result);
            }
            return result;
        }
    }
}
