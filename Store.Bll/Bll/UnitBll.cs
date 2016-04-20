using System.Linq;
using Store.Common;
using Store.Common.Helper;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IUnitBll : IBaseBll<Unit>
    {
        new IQueryable<Unit> GetAll();
    }

    public class UnitBll : BaseBll<Unit, IUnitDal>, IUnitBll
    {
        protected IFactoryDal FactoryDal;

        public UnitBll(IFactoryDal factoryDal)
            : base(factoryDal.UnitDal)
        {
            FactoryDal = factoryDal;
        }

        public new IQueryable<Unit> GetAll()
        {
            IQueryable<Unit> result = CacheHelper.GetObjectFromCache<IQueryable<Unit>>(GlobalConstants.UnitsKey);
            if (result == null)
            {
                result = base.GetAll();
                CacheHelper.AddObjectToCache(GlobalConstants.UnitsKey, result);
            }
            return result;
        }
    }
}
