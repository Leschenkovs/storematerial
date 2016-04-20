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
		new IQueryable<Role> GetAll();
	}

	public class RoleBll : BaseBll<Role, IRoleDal>, IRoleBll
	{
		protected IFactoryDal FactoryDal;

		public RoleBll(IFactoryDal factoryDal)
			: base(factoryDal.RoleDal)
		{
			FactoryDal = factoryDal;
		}

		public new IQueryable<Role> GetAll()
		{
			IQueryable<Role> result = CacheHelper.GetObjectFromCache<IQueryable<Role>>(GlobalConstants.RolesKey);
			if (result == null)
			{
				result = base.GetAll();
				CacheHelper.AddObjectToCache(GlobalConstants.RolesKey, result);
			}
			return result;
		}
	}
}
