using System.Collections.Generic;
using System.Linq;
using Store.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
  public interface IExperseBll
  {
	 IList<Experse> GetAll();
  }

  public class ExperseBll : IExperseBll
  {
	 protected IFactoryDal FactoryDal;

	 public ExperseBll(IFactoryDal factoryDal)
	 {
		FactoryDal = factoryDal;
	 }

	 public IList<Experse> GetAll()
	 {
		return FactoryDal.ExperseDal.GetAll().OrderByDescending(x => x.AddedDate).ToList();
	 }

  }
}
