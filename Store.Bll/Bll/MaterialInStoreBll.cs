using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IMaterialInStoreBll : IBaseBll<MaterialInStore>
	{
	}

	public class MaterialInStoreBll : BaseBll<MaterialInStore, IMaterialInStoreDal>, IMaterialInStoreBll
	{
		protected IFactoryDal FactoryDal;

        public MaterialInStoreBll(IFactoryDal factoryDal)
            : base(factoryDal.MaterialInStoreDal)
		{
			FactoryDal = factoryDal;
		}

	}
}
