
using Store.Model;

namespace Store.Dal.Dal
{
    public interface IMaterialInStoreDal : IGenericRepository<MaterialInStore>
    {
    }

    public class MaterialInStoreDal : GenericRepository<DataContext, MaterialInStore>, IMaterialInStoreDal
    {
    }
}
