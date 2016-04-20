using Store.Bll.Exception;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IUserBll : IBaseBll<User>
    {
        User Add(User obj);
        User Update(User obj);
        User GetByTnAndPassword(string tn, string psw);
    }

    public class UserBll : BaseBll<User, IUserDal>, IUserBll
    {
        protected IFactoryDal FactoryDal;

        public UserBll(IFactoryDal factoryDal)
            : base(factoryDal.UserDal)
        {
            FactoryDal = factoryDal;
        }

        public User Add(User obj)
        {
            bool isExist = GetByTn(obj.Tn) != null;
            if (isExist)
            {
                throw new DbOwnException("Работник ТН = " + obj.Tn + " уже существует в БД!");
            }
            User newObj = Save(obj);
            return newObj;
        }

        public User Update(User obj)
        {
            User user = GetByTn(obj.Tn);
            if (user != null && user.Id != obj.Id)
            {
                throw new DbOwnException("Работник ТН = " + obj.Tn + " уже существует в БД!");
            }
            User objAfterUpdate = Save(obj);
            return objAfterUpdate;
        }

        public User GetByTnAndPassword(string tn, string psw)
        {
            User user = FactoryDal.UserDal.First(x => x.Tn == tn.Trim() && x.Password == psw);
            return user;
        }

        private User GetByTn(string tn)
        {
            return FactoryDal.UserDal.First(x => x.Tn == tn.Trim());
        }
    }
}
