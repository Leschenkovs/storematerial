using System;
using System.Linq;
using Store.Dal;

namespace Store.Bll.Bll
{
    public interface IBaseBll<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        T Save(T entity);
        bool Delete(int id);
        T Create();
    }

    public abstract class BaseBll<T, TC> :
        IBaseBll<T>
        where T : class
        where TC : IGenericRepository<T>
    {
        private readonly TC EntityDal;

        protected BaseBll(TC entityDal)
        {
            if (entityDal == null)
            {
                throw new ArgumentNullException("entityDal");
            }
            EntityDal = entityDal;
        }

        public T GetById(int id)
        {
            return EntityDal.GetById(id);
        }

        public IQueryable<T> GetAll()
        {
            return EntityDal.GetAll();
        }

        public T Save(T entity)
        {
            return EntityDal.Save(entity);
        }

        public bool Delete(int id)
        {
            T entity = GetById(id);
            return EntityDal.Delete(entity);
        }

        public T Create()
        {
            return EntityDal.Create();
        }
    }
}
