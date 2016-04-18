using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
  public interface IRoleBll : IBaseBll<Role>
	{
	}

  public class RoleBll : BaseBll<Role, IRoleDal>, IRoleBll
	{
		protected IFactoryDal FactoryDal;

		public RoleBll(IFactoryDal factoryDal)
		  : base(factoryDal.RoleDal)
		{
			FactoryDal = factoryDal;
		}

	}
}
