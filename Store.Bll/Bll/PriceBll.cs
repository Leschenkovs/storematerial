using System.Collections.Generic;
using System.Linq;
using Store.Bll.Exception;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IPriceBll : IBaseBll<Price>
	{
		IList<Price> GetByMaterialInStoreId(int id);
        Price Add(Price model);
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
			return FactoryDal.PriceDal.FindBy(x => x.Id == id).OrderBy(x => x.DateOt).ToList();
		}

        public Price Add(Price model)
        {
            bool isExistPrice = IsExistPrice(model);
            if (isExistPrice)
            {
                throw new DbOwnException("Цена уже установлена!");
            }
            return base.Save(model);
        }

        private bool IsExistPrice(Price model)
        {
            return FactoryDal.PriceDal.First(
                x =>
                    x.MaterialInStoreId == model.MaterialInStoreId && x.DateOt.Month == model.DateOt.Month &&
                    x.DateOt.Year == model.DateOt.Year) != null;
        }

	}
}
