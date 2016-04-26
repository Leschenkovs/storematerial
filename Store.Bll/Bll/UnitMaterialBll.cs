using System.Collections.Generic;
using System.Linq;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IUnitMaterialBll : IBaseBll<UnitMaterial>
    {
        IList<UnitMaterial> GetByKindMaterialId(int id);
    }

    public class UnitMaterialBll : BaseBll<UnitMaterial, IUnitMaterialDal>, IUnitMaterialBll
    {
        protected IFactoryDal FactoryDal;

        public UnitMaterialBll(IFactoryDal factoryDal)
            : base(factoryDal.UnitMaterialDal)
        {
            FactoryDal = factoryDal;
        }

        public IList<UnitMaterial> GetByKindMaterialId(int id)
        {
            IList<UnitMaterial> list =
                FactoryDal.UnitMaterialDal.FindBy(x => x.KindMaterialId == id).OrderBy(x => x.UnitObj.ShortName).ToList();
            return list;
        }
    }
}
