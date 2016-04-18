using System;
using System.Linq;
using Store.Dal;

namespace Store.Bll.Bll
{
	public interface IBaseBll<T> where T : class
	{
		T GetById(int id);
		IQueryable<T> GetAll();
		T Add(T entity);
		T Update(T entity);
		bool Delete(int id);
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

		public T Add(T entity)
		{
			return EntityDal.Add(entity);
		}

		public T Update(T entity)
		{
			return EntityDal.Update(entity);
		}

		public bool Delete(int id)
		{
			T entity = GetById(id);
			return EntityDal.Delete(entity);
		}
	}
}
