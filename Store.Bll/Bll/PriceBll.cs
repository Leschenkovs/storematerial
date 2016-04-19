using System.Collections.Generic;
using System.Linq;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IPriceBll : IBaseBll<Price>
	{
		IList<Price> GetByMaterialInStoreId(int id);
	}

    public class PriceBll : BaseBll<Price, IPriceDal>, IPriceBll
	{
		protected IFactoryDal FactoryDal;

        public PriceBll(IFactoryDal factoryDal)
            : base(factoryDal.PriceDal)
		{
			FactoryDal = factoryDal;
		}

		public IList<Price> GetByMaterialInStoreId(int id)
		{
			return FactoryDal.PriceDal.FindBy(x => x.Id == id).OrderBy(x => x.DateDo).ToList();
		}

	}
}
