
using Store.Bll.Bll;
using Store.Dal;

namespace Store.Bll
{
    public interface IFactoryBll
    {
        
    }
    public class FactoryBll: IFactoryBll
    {
        private readonly IFactoryDal _factoryDal;

        public FactoryBll()
        {
            _factoryDal = new FactoryDal();
        }

        private IUserBll _userBll;
        public IUserBll UserBll
        {
            get { return _userBll ?? (_userBll = new UserBll(_factoryDal)); }
        }


    }
}
