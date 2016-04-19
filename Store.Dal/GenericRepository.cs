using System;
using System.Data.Entity;
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
		T Add(T entity);
		bool Delete(T entity);
		T Update(T entity);
		void Save();
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

		public T First(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
		{
			T obj = _entities.Set<T>().FirstOrDefault(predicate);
			return obj;
		}

		public T GetById(int id)
		{
			T query = _entities.Set<T>().Find(id);
			return query;
		}

		public virtual T Add(T entity)
		{
			try
			{
				_entities.Set<T>().Add(entity);
				_entities.SaveChanges();
				return entity;
			}
			catch (Exception e)
			{
				return null;
			}
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
				return false;
			}
		}

		public virtual T Update(T entity)
		{
			try
			{
                //_entities.Set<T>().Attach(entity);
                _entities.Entry(entity).State = EntityState.Modified;
				_entities.SaveChanges();
				return entity;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public virtual void Save()
		{
			_entities.SaveChanges();
		}
	}
}
