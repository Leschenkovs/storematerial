using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IExperseBll : IBaseBll<Experse>
  {

  }

    public class ExperseBll : BaseBll<Experse, IExperseDal>, IExperseBll
  {
	 protected IFactoryDal FactoryDal;

	 public ExperseBll(IFactoryDal factoryDal):base(factoryDal.ExperseDal)
	 {
		FactoryDal = factoryDal;
	 }

  }
}
