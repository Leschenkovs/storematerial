﻿using Store.Bll.Exception;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IUserBll : IBaseBll<User>
    {
        User Add(User obj);
        User Update(User obj);
        User GetByLoginAndPassword(string login, string psw);
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
            bool isExist = GetByTn(obj.Login) != null;
            if (isExist)
            {
                throw new DbOwnException("Работник ТН = " + obj.Login + " уже существует в БД!");
            }
            User newObj = Save(obj);
            return newObj;
        }

        public User Update(User obj)
        {
            User user = GetByTn(obj.Login);
            if (user != null && user.Id != obj.Id)
            {
                throw new DbOwnException("Работник ТН = " + obj.Login + " уже существует в БД!");
            }
            User objAfterUpdate = Save(obj);
            return objAfterUpdate;
        }

        public User GetByLoginAndPassword(string login, string psw)
        {
            User user = FactoryDal.UserDal.First(x => x.Login == login.Trim() && x.Password == psw);
            return user;
        }

        private User GetByTn(string tn)
        {
            return FactoryDal.UserDal.First(x => x.Login == tn.Trim());
        }
    }
}
