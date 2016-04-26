using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Dal
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        T First(Expression<Func<T, bool>> predicate);

        T GetById(int id);
        bool Delete(T entity);
        T Save(T entity);
        T Create();
    }

    public abstract class GenericRepository<C, T> :
        IGenericRepository<T>
        where T : class
        where C : DbContext, new()
    {

        private C _entities = new C();

        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            T obj = _entities.Set<T>().FirstOrDefault(predicate);
            return obj;
        }

        public T GetById(int id)
        {
            _entities.RefreshAllEntites(RefreshMode.StoreWins);
            T query = _entities.Set<T>().Find(id);
        //    _entities.Entry(query).Reload();
            return query;
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                _entities.Set<T>().Remove(entity);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public virtual T Save(T entity)
        {
            try
            {
                _entities.Set<T>().AddOrUpdate(entity);
                //_entities.Entry(entity).State = EntityState.Modified;
                _entities.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public T Create()
        {
            return _entities.Set<T>().Create();
        }
    }
}
