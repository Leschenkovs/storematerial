using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IUnitBll : IBaseBll<Unit>
    {
    }

    public class UnitBll : BaseBll<Unit, IUnitDal>, IUnitBll
    {
        protected IFactoryDal FactoryDal;

        public UnitBll(IFactoryDal factoryDal)
            : base(factoryDal.UnitDal)
        {
            FactoryDal = factoryDal;
        }
    }
}
