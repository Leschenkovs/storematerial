using System.Collections.Generic;
using System.Linq;
using Store.Bll.Exception;
using Store.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
	public interface IUserBll
	{
		User GetByTn(string tn);
		IList<User> GetAll();
		User Add(User obj);
		User Update(User obj);
		bool Delete(int id);
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
			return FactoryDal.UserDal.GetAll().OrderBy(x=>x.Tn).ToList();
		}

		public User Add(User obj)
		{
			bool isExist = FactoryDal.UserDal.First(x => x.Tn == obj.Tn.Trim()) != null ? true : false;
			if (isExist) throw new DbOwnException("Работник ТН = " + obj.Tn + " уже существует в БД!");

			User newObj = FactoryDal.UserDal.Add(obj);
			return newObj;
		}

		public User Update(User obj)
		{
			return FactoryDal.UserDal.Update(obj);
		}

		public bool Delete(int id)
		{
			User obj = FactoryDal.UserDal.First(x => x.Id == id);
			if (obj == null) throw new DbOwnException ("Пользователя ID = " + id + " нет в БД!");
			return FactoryDal.UserDal.Delete(obj);
		}
	}
}
