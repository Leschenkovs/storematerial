using System.Collections.Generic;
using System.Linq;
using Store.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
	public interface IPriceBll
	{
		IList<Price> GetByMaterialInStoreId(int id);
		Price Update(Price obj);
	}

	public class PriceBll : IPriceBll
	{
		protected IFactoryDal FactoryDal;

		public PriceBll(IFactoryDal factoryDal)
		{
			FactoryDal = factoryDal;
		}

		public IList<Price> GetByMaterialInStoreId(int id)
		{
			return FactoryDal.PriceDal.FindBy(x => x.Id == id).OrderBy(x => x.DateDo).ToList();
		}

		public Price Update(Price obj)
		{
		  return FactoryDal.PriceDal.Update(obj);
		}
	}
}
