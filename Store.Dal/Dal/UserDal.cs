
using Store.Model;

namespace Store.Dal.Dal
{
    public interface IUserDal : IGenericRepository<User>
    {
    }

    public class UserDal : GenericRepository<DataContext, User>, IUserDal
    {
    }
}
