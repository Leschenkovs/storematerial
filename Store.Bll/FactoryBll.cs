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
		IKindMaterialBll KindMaterialBll { get; }
		ISupplyBll SupplyBll { get; }
		IUnitMaterialBll UnitMaterialBll { get; }
		IExperseBll ExperseBll { get; }
		IMaterialInStoreBll MaterialInStoreBll { get; }
		IPriceBll PriceBll { get; }
        IUnitBll UnitBll { get; }
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

		private IKindMaterialBll _kindMaterialBll;
		public IKindMaterialBll KindMaterialBll
		{
		  get { return _kindMaterialBll ?? (_kindMaterialBll = new KindMaterialBll(_factoryDal)); }
		}

		private ISupplyBll _supplyBll;
		public ISupplyBll SupplyBll
		{
		  get { return _supplyBll ?? (_supplyBll = new SupplyBll(_factoryDal)); }
		}

		private IUnitMaterialBll _unitMaterialBll;
		public IUnitMaterialBll UnitMaterialBll
		{
		  get { return _unitMaterialBll ?? (_unitMaterialBll = new UnitMaterialBll(_factoryDal)); }
		}

		private IExperseBll _experseBll;
		public IExperseBll ExperseBll
		{
		  get { return _experseBll ?? (_experseBll = new ExperseBll(_factoryDal)); }
		}

		private IMaterialInStoreBll _materialInStoreBll;
		public IMaterialInStoreBll MaterialInStoreBll
		{
		  get { return _materialInStoreBll ?? (_materialInStoreBll = new MaterialInStoreBll(_factoryDal)); }
		}

		private IPriceBll _priceBll;
		public IPriceBll PriceBll
		{
		  get { return _priceBll ?? (_priceBll = new PriceBll(_factoryDal)); }
		}

        private IUnitBll _unitBll;
        public IUnitBll UnitBll
        {
            get { return _unitBll ?? (_unitBll = new UnitBll(_factoryDal)); }
        }

	}
}
