using System.Linq;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IKindMaterialBll : IBaseBll<KindMaterial>
	{	  
	    bool IsExistMaterialInStore(int id);
	}

    public class KindMaterialBll : BaseBll<KindMaterial, IKindMaterialDal>, IKindMaterialBll
	{
		protected IFactoryDal FactoryDal;

        public KindMaterialBll(IFactoryDal factoryDal)
            : base(factoryDal.KindMaterialDal)
		{
			FactoryDal = factoryDal;
		}


		public bool IsExistMaterialInStore(int id)
		{
			return FactoryDal.KindMaterialDal.First(x => x.Id == id).MaterialInStores.Any();
		}

	}
}
