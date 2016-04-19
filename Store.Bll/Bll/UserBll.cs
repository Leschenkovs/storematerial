using Store.Bll.Exception;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
	public interface IUserBll : IBaseBll<User>
	{
		new User Add(User obj);
	}

	public class UserBll : BaseBll<User, IUserDal>, IUserBll
	{
		protected IFactoryDal FactoryDal;

		public UserBll(IFactoryDal factoryDal) : base(factoryDal.UserDal)
		{
			FactoryDal = factoryDal;
		}

		public new User Add(User obj)
		{
			bool isExist = FactoryDal.UserDal.First(x => x.Tn == obj.Tn.Trim()) != null;
			if (isExist) {throw new DbOwnException("Работник ТН = " + obj.Tn + " уже существует в БД!");}

			User newObj = base.Add(obj);
			return newObj;
		}
	}
}
