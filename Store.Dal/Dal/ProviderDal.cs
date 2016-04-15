
using Store.Model;

namespace Store.Dal.Dal
{
    public interface IProviderDal : IGenericRepository<Provider>
    {
    }

    public class ProviderDal : GenericRepository<DataContext, Provider>, IProviderDal
    {
    }
}
