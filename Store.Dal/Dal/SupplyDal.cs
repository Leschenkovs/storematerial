
using Store.Model;

namespace Store.Dal.Dal
{
    public interface ISupplyDal : IGenericRepository<Supply>
    {
    }

    public class SupplyDal : GenericRepository<DataContext, Supply>, ISupplyDal
    {
    }
}
