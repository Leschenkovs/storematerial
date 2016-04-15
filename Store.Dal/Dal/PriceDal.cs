
using Store.Model;

namespace Store.Dal.Dal
{
    public interface IPriceDal : IGenericRepository<Price>
    {
    }

    public class PriceDal : GenericRepository<DataContext, Price>, IPriceDal
    {
    }
}
