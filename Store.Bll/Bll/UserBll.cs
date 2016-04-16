
using System.Collections.Generic;
using System.Linq;
using Store.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
	public interface IUserBll
	{
		User GetByTn(string tn);
		IList<User> GetAll();
	}

	public class UserBll : IUserBll
	{
		protected IFactoryDal FactoryDal;

		public UserBll(IFactoryDal factoryDal)
		{
			FactoryDal = factoryDal;
		}

		public User GetByTn(string tn)
		{
			return FactoryDal.UserDal.First(x => x.Tn == tn);
		}

		public IList<User> GetAll()
		{
			return FactoryDal.UserDal.GetAll().ToList();
		}
	}
}
