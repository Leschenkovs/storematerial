
using Store.Model;

namespace Store.Dal.Dal
{
    public interface IExperseDal : IGenericRepository<Experse>
    {
    }

    public class ExperseDal : GenericRepository<DataContext, Experse>, IExperseDal
    {
    }
}
