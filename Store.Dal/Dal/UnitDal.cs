
using Store.Model;

namespace Store.Dal.Dal
{
    public interface IUnitDal : IGenericRepository<Unit>
    {
    }

    public class UnitDal : GenericRepository<DataContext, Unit>, IUnitDal
    {
    }
}
