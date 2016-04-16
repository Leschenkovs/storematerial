using System.Collections.Generic;
using System.Linq;
using Store.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
	public interface IRoleBll
	{
		IList<Role> GetAll();
	}

	public class RoleBll : IRoleBll
	{
		protected IFactoryDal FactoryDal;

		public RoleBll(IFactoryDal factoryDal)
		{
			FactoryDal = factoryDal;
		}

		public IList<Role> GetAll()
		{
			IList<Role> list = FactoryDal.RoleDal.GetAll().ToList();
			return list;
		}

	}
}
