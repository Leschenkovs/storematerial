
using Store.Model;

namespace Store.Dal.Dal
{
    public interface ICostumerDal : IGenericRepository<Costumer>
    {
    }

    public class CostumerDal : GenericRepository<DataContext, Costumer>, ICostumerDal
    {
    }
}
