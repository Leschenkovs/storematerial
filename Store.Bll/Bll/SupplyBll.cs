using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
	public interface ISupplyBll :IBaseBll<Supply>
	{
	}

  public class SupplyBll: BaseBll<Supply, ISupplyDal>, ISupplyBll
  {
		protected IFactoryDal FactoryDal;

		public SupplyBll(IFactoryDal factoryDal) : base(factoryDal.SupplyDal)
		{
			FactoryDal = factoryDal;
		}

  }
}
