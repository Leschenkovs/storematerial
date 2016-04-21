using System.Linq;
using Store.Bll.Exception;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface ISupplyBll : IBaseBll<Supply>
    {
        new bool Delete(int id);
    }

    public class SupplyBll : BaseBll<Supply, ISupplyDal>, ISupplyBll
    {
        protected IFactoryDal FactoryDal;

        public SupplyBll(IFactoryDal factoryDal) : base(factoryDal.SupplyDal)
        {
            FactoryDal = factoryDal;
        }

        public new bool Delete(int id)
        {
            bool isIncreaseCountMaterialInStore = IncreaseCountMaterialInStore(id);
            if (isIncreaseCountMaterialInStore)
            {
                return base.Delete(id);
            }
            return false;
        }

        private bool IncreaseCountMaterialInStore(int id)
        {
            Supply obj = FactoryDal.SupplyDal.First(x => x.Id == id);
            MaterialInStore objMaterialInStore = obj.MaterialInStoreObj;
            if (objMaterialInStore == null)
            {
                throw new DbOwnException("Материал отсутствует на складе!");
            }
            if (objMaterialInStore.Count < obj.Count)
            {
                throw new DbOwnException("Расход по материалу уже произведён, удаление поставки невозможно!");
            }
            objMaterialInStore.Count = objMaterialInStore.Count - obj.Count;
            if (FactoryDal.MaterialInStoreDal.Save(objMaterialInStore) != null) return true;

            return false;
        }
    }
}
