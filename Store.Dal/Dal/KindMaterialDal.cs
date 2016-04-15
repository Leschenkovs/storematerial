
using Store.Model;

namespace Store.Dal.Dal
{
    public interface IKindMaterialDal : IGenericRepository<KindMaterial>
    {
    }

    public class KindMaterialDal : GenericRepository<DataContext, KindMaterial>, IKindMaterialDal
    {
    }
}
