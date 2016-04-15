
using Store.Model;

namespace Store.Dal.Dal
{
    public interface IRoleDal : IGenericRepository<Role>
    {
    }

    public class RoleDal : GenericRepository<DataContext, Role>, IRoleDal
    {
    }
}
