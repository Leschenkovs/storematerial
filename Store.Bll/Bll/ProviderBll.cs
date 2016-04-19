using Store.Dal;
using Store.Dal.Dal;

namespace Store.Bll.Bll
{
    public interface IProviderBll : IBaseBll<Model.Provider>
	{
	}

    public class ProviderBll : BaseBll<Model.Provider, IProviderDal>, IProviderBll
	{
		protected IFactoryDal FactoryDal;

        public ProviderBll(IFactoryDal factoryDal)
            : base(factoryDal.ProviderDal)
		{
			FactoryDal = factoryDal;
		}

	}
}
