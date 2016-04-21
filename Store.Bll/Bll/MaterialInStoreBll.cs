using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IMaterialInStoreBll : IBaseBll<MaterialInStore>
    {
        MaterialInStore Add(MaterialInStore obj);
    }

	public class MaterialInStoreBll : BaseBll<MaterialInStore, IMaterialInStoreDal>, IMaterialInStoreBll
	{
		protected IFactoryDal FactoryDal;

        public MaterialInStoreBll(IFactoryDal factoryDal)
            : base(factoryDal.MaterialInStoreDal)
		{
			FactoryDal = factoryDal;
		}

	    public MaterialInStore Add(MaterialInStore obj)
	    {
	        MaterialInStore objNew = FactoryDal.MaterialInStoreDal.First(x => x.UnitMaterialId == obj.UnitMaterialId);
	        if (objNew == null)
	        {
	            objNew = FactoryDal.MaterialInStoreDal.Save(obj);
	        }
	        else
	        {
	            objNew.Count = objNew.Count + obj.Count;
	            FactoryDal.MaterialInStoreDal.Save(objNew);
	        }
            return objNew;
	    }

	}
}
