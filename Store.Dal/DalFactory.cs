
using System.Diagnostics.CodeAnalysis;
using Store.Dal.Dal;

namespace Store.Dal
{
	public interface IFactoryDal
	{
		ICostumerDal CostumerDal { get; }
		IExperseDal ExperseDal { get; }
		IKindMaterialDal KindMaterialDal { get; }
		IMaterialInStoreDal MaterialInStoreDal { get; }
		IPriceDal PriceDal { get; }
		IProviderDal ProviderDal { get; }
		IRoleDal RoleDal { get; }
		ISupplyDal SupplyDal { get; }
		IUnitDal UnitDal { get; }
		IUnitMaterialDal UnitMaterialDal { get; }
		IUserDal UserDal { get; }
	}

	public class FactoryDal : IFactoryDal
	{
		private ICostumerDal costumerDal;

		[ExcludeFromCodeCoverage]
		public ICostumerDal CostumerDal
		{
			get { return costumerDal ?? (costumerDal = new CostumerDal()); }
		}

		private IExperseDal experseDal;

		[ExcludeFromCodeCoverage]
		public IExperseDal ExperseDal
		{
			get { return experseDal ?? (experseDal = new ExperseDal()); }
		}

		private IKindMaterialDal kindMaterialDal;

		[ExcludeFromCodeCoverage]
		public IKindMaterialDal KindMaterialDal
		{
			get { return kindMaterialDal ?? (kindMaterialDal = new KindMaterialDal()); }
		}

		private IMaterialInStoreDal materialInStoreDal;

		[ExcludeFromCodeCoverage]
		public IMaterialInStoreDal MaterialInStoreDal
		{
			get { return materialInStoreDal ?? (materialInStoreDal = new MaterialInStoreDal()); }
		}

		private IPriceDal priceDal;

		[ExcludeFromCodeCoverage]
		public IPriceDal PriceDal
		{
			get { return priceDal ?? (priceDal = new PriceDal()); }
		}

		private IProviderDal providerDal;

		[ExcludeFromCodeCoverage]
		public IProviderDal ProviderDal
		{
			get { return providerDal ?? (providerDal = new ProviderDal()); }
		}

		private IRoleDal roleDal;

		[ExcludeFromCodeCoverage]
		public IRoleDal RoleDal
		{
			get { return roleDal ?? (roleDal = new RoleDal()); }
		}

		private ISupplyDal supplyDal;

		[ExcludeFromCodeCoverage]
		public ISupplyDal SupplyDal
		{
			get { return supplyDal ?? (supplyDal = new SupplyDal()); }
		}

		private IUnitDal unitDal;

		[ExcludeFromCodeCoverage]
		public IUnitDal UnitDal
		{
			get { return unitDal ?? (unitDal = new UnitDal()); }
		}

		private IUnitMaterialDal unitMaterialDal;

		[ExcludeFromCodeCoverage]
		public IUnitMaterialDal UnitMaterialDal
		{
			get { return unitMaterialDal ?? (unitMaterialDal = new UnitMaterialDal()); }
		}

		private IUserDal userDal;

		[ExcludeFromCodeCoverage]
		public IUserDal UserDal
		{
			get { return userDal ?? (userDal = new UserDal()); }
		}
	}
}
