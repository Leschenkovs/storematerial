using System.Collections.Generic;
using System.Linq;
using Store.Bll.Exception;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
  public interface ICostumerBll : IBaseBll<Costumer>
  {
	 new Costumer AddCostumer(Costumer obj);
  }

  public class CostumerBll : BaseBll<Costumer, ICostumerDal>, ICostumerBll
  {
	 protected IFactoryDal FactoryDal;

	 public CostumerBll(IFactoryDal factoryDal)
		: base(factoryDal.CostumerDal)
	 {
		FactoryDal = factoryDal;
	 }

	 public new Costumer AddCostumer(Costumer obj)
	 {
		bool isExist = FactoryDal.CostumerDal.First(x => x.Id == obj.Id) == null ? true : false;
		if (isExist) {throw new DbOwnException("Потребитель уже существует в БД!");}

		Costumer newObj = base.Add(obj);
		return newObj;
	 }

  }
}
