using System.Collections.Generic;
using System.Linq;
using Store.Bll.Exception;
using Store.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
  public interface ICostumerBll
  {
	 Costumer GetById(int id);
	 IList<Costumer> GetAll();
	 Costumer AddCostumer(Costumer obj);
	 Costumer UpdateCostumer(Costumer obj);
	 bool DeleteCostumer(int id);
  }

  public class CostumerBll : ICostumerBll
  {
	 protected IFactoryDal FactoryDal;

	 public CostumerBll(IFactoryDal factoryDal)
	 {
		FactoryDal = factoryDal;
	 }

	 public Costumer GetById(int id)
	 {
		return FactoryDal.CostumerDal.First(x => x.Id == id);
	 }

	 public IList<Costumer> GetAll()
	 {
		return FactoryDal.CostumerDal.GetAll().OrderBy(x=>x.Name).ToList();
	 }

	 public Costumer AddCostumer(Costumer obj)
	 {
		bool isExist = FactoryDal.CostumerDal.First(x => x.Id == obj.Id) == null ? true : false;
		if (isExist) throw new DbOwnException("Потребитель уже существует в БД!");

		Costumer newObj = FactoryDal.CostumerDal.Add(obj);
		return newObj;
	 }

	 public Costumer UpdateCostumer(Costumer obj)
	 {
		return FactoryDal.CostumerDal.Update(obj);
	 }

	 public bool DeleteCostumer(int id)
	 {
		Costumer obj = FactoryDal.CostumerDal.First(x => x.Id == id);
		if (obj == null) throw new DbOwnException("Потребитель отсутствует в БД!");
		return FactoryDal.CostumerDal.Delete(obj);
	 }

  }
}
