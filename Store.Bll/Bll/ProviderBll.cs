using System.Collections.Generic;
using System.Linq;
using Store.Bll.Exception;
using Store.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
	public interface IProviderBll
	{
	  Model.Provider GetById(int id);
	  IList<Model.Provider> GetAll();
	  Model.Provider AddProvider(Model.Provider obj);
	  Model.Provider UpdateProvider(Model.Provider obj);
	  bool DeleteProvider(int id);
	}

	public class ProviderBll : IProviderBll
	{
		protected IFactoryDal FactoryDal;

		public ProviderBll(IFactoryDal factoryDal)
		{
			FactoryDal = factoryDal;
		}

		public Model.Provider GetById(int id)
		{
		  return FactoryDal.ProviderDal.First(x => x.Id == id);
		}

		public IList<Model.Provider> GetAll()
		{
		  return FactoryDal.ProviderDal.GetAll().OrderBy(x=>x.Name).ToList();
		}

		public Model.Provider AddProvider(Model.Provider obj)
		{
		  bool isExist = FactoryDal.ProviderDal.First(x => x.Id == obj.Id) == null ? true : false;
		  if (isExist) throw new DbOwnException("Поставщик уже существует в БД!");

		  Model.Provider newObj = FactoryDal.ProviderDal.Add(obj);
		  return newObj;
		}

		public Model.Provider UpdateProvider(Model.Provider obj)
		{
		  return FactoryDal.ProviderDal.Update(obj);
		}

		public bool DeleteProvider(int id)
		{
		  Model.Provider obj = FactoryDal.ProviderDal.First(x => x.Id == id);
		  if (obj == null) throw new DbOwnException("Поставщик отсутствует в БД!");
		  return FactoryDal.ProviderDal.Delete(obj);
		}

	}
}
