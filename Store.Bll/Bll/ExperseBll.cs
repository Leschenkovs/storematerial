using System;
using System.Linq;
using Store.Bll.Exception;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
	public interface IExperseBll : IBaseBll<Experse>
	{
		new bool Save(Experse model);
	}

	public class ExperseBll : BaseBll<Experse, IExperseDal>, IExperseBll
	{
		protected IFactoryDal FactoryDal;

		public ExperseBll(IFactoryDal factoryDal) : base(factoryDal.ExperseDal)
		{
			FactoryDal = factoryDal;
		}

		public new bool Save(Experse model)
		{
			decimal price = SeekPrice(model.MaterialInStoreId);
			model.FullCost = price*model.Count;

			bool isDecreaseCountMaterialInStore = DecreaseCountMaterialInStore(model);
			if (isDecreaseCountMaterialInStore)
			{
				return base.Save(model) != null;
			}
			return false;
		}

		private bool DecreaseCountMaterialInStore(Experse model)
		{
			MaterialInStore objMaterialInStore =
				FactoryDal.MaterialInStoreDal.First(x => x.UnitMaterialId == model.MaterialInStoreId);
			if (objMaterialInStore == null)
			{
				throw new DbOwnException("Материал отсутствует на складе!");
			}
			if (objMaterialInStore.Count < model.Count)
			{
				throw new DbOwnException("Недостаточно материала на складе!");
			}
			objMaterialInStore.Count = objMaterialInStore.Count - model.Count;
			if (FactoryDal.MaterialInStoreDal.Save(objMaterialInStore) != null) return true;

			return false;
		}

		private decimal SeekPrice(int id)
		{
			MaterialInStore objMaterialInStore =
				FactoryDal.MaterialInStoreDal.First(x => x.UnitMaterialId == id);
			if (objMaterialInStore == null)
			{
				throw new DbOwnException("Материал отсутствует на складе!");
			}
			DateTime dateNow = DateTime.Now;
			Price objPrice =
				objMaterialInStore.Prices.FirstOrDefault(x => x.DateOt.Year == dateNow.Year && x.DateOt.Month == dateNow.Month);
			if (objPrice == null)
			{
				throw new DbOwnException("Отсутствует цена на материал за текущий месяц!");
			}

			return objPrice.PriceValue;
		}

	}
}
