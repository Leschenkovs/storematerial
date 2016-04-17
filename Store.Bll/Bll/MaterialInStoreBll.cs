using System.Collections.Generic;
using System.Linq;
using Store.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
	public interface IMaterialInStoreBll
	{
	  IList<MaterialInStore> GetAll();
	}

	public class MaterialInStoreBll : IMaterialInStoreBll
	{
		protected IFactoryDal FactoryDal;

		public MaterialInStoreBll(IFactoryDal factoryDal)
		{
			FactoryDal = factoryDal;
		}

		public IList<MaterialInStore> GetAll()
		{
		  return FactoryDal.MaterialInStoreDal.GetAll().OrderBy(x => x.KindMaterialObj.Name).ToList();
		}

	}
}
