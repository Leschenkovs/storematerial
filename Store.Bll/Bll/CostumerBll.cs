using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
  public interface ICostumerBll : IBaseBll<Costumer>
  {
  }

  public class CostumerBll : BaseBll<Costumer, ICostumerDal>, ICostumerBll
  {
	 protected IFactoryDal FactoryDal;

	 public CostumerBll(IFactoryDal factoryDal)
		: base(factoryDal.CostumerDal)
	 {
		FactoryDal = factoryDal;
	 }

  }
}
