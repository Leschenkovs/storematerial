using System.Collections.Generic;
using System.Linq;
using Store.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
	public interface ISupplyBll
	{
	  IList<Supply> GetAll();
	}

  public class SupplyBll: ISupplyBll
  {
		protected IFactoryDal FactoryDal;

		public SupplyBll(IFactoryDal factoryDal)
		{
			FactoryDal = factoryDal;
		}

		public IList<Supply> GetAll()
		{
		  return FactoryDal.SupplyDal.GetAll().OrderByDescending(x => x.AddedDate).ToList();
		}

  }
}
