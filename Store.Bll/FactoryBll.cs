using Store.Bll.Bll;
using Store.Dal;

namespace Store.Bll
{
	public interface IFactoryBll
	{
		IUserBll UserBll { get; }
		IRoleBll RoleBll { get; }
		IProviderBll ProviderBll { get; }
		ICostumerBll CostumerBll { get; }
	}

	public class FactoryBll : IFactoryBll
	{
		private readonly IFactoryDal _factoryDal;

		public FactoryBll()
		{
			_factoryDal = new FactoryDal();
		}

		private IUserBll _userBll;
		public IUserBll UserBll
		{
			get { return _userBll ?? (_userBll = new UserBll(_factoryDal)); }
		}

		private IRoleBll _roleBll;
		public IRoleBll RoleBll
		{
			get { return _roleBll ?? (_roleBll = new RoleBll(_factoryDal)); }
		}

		private IProviderBll _providerBll;
		public IProviderBll ProviderBll
		{
		  get { return _providerBll ?? (_providerBll = new ProviderBll(_factoryDal)); }
		}

		private ICostumerBll _costumerBll;
		public ICostumerBll CostumerBll
		{
		  get { return _costumerBll ?? (_costumerBll = new CostumerBll(_factoryDal)); }
		}
	}
}
