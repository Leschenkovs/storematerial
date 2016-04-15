
using Store.Dal;

namespace Store.Bll.Bll
{
    public interface IUserBll
    {
        
    }
    public class UserBll: IUserBll
    {
        protected IFactoryDal FactoryDal;
        public UserBll(IFactoryDal factoryDal)
        {
            FactoryDal = factoryDal;
        }

    }
}
