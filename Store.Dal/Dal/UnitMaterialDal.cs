
using Store.Model;

namespace Store.Dal.Dal
{
    public interface IUnitMaterialDal : IGenericRepository<UnitMaterial>
    {
    }

    public class UnitMaterialDal : GenericRepository<DataContext, UnitMaterial>, IUnitMaterialDal
    {
    }
}
