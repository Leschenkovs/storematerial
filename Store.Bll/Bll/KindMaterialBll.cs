using System.Collections.Generic;
using System.Linq;
using Store.Bll.Exception;
using Store.Common;
using Store.Common.Helper;
using Store.Dal;
using Store.Dal.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
    public interface IKindMaterialBll : IBaseBll<KindMaterial>
    {
        new List<KindMaterial> GetAll();
        new KindMaterial Save(KindMaterial entity);
        new bool Delete(int id);
    }

    public class KindMaterialBll : BaseBll<KindMaterial, IKindMaterialDal>, IKindMaterialBll
    {
        protected IFactoryDal FactoryDal;

        public KindMaterialBll(IFactoryDal factoryDal)
            : base(factoryDal.KindMaterialDal)
        {
            FactoryDal = factoryDal;
        }

        public new List<KindMaterial> GetAll()
        {
            List<KindMaterial> result = CacheHelper.GetObjectFromCache<List<KindMaterial>>(GlobalConstants.KindMaterialsKey);
            if (result == null)
            {
                result = base.GetAll().ToList();
                CacheHelper.AddObjectToCache(GlobalConstants.KindMaterialsKey, result);
            }
            return result;
        }

        public new KindMaterial Save(KindMaterial entity)
        {
            CacheHelper.CleanCache(GlobalConstants.KindMaterialsKey);
            return base.Save(entity);
        }

        public new bool Delete(int id)
        {
            bool isExistMaterialInStore = IsExistMaterialInStore(id);
            if (isExistMaterialInStore) { throw new DbOwnException("На складе имеются остатки этого материала, удаление не возможно!"); }
            return base.Delete(id);
        }

        private bool IsExistMaterialInStore(int id)
        {
            return FactoryDal.KindMaterialDal.First(x => x.Id == id).UnitMaterials.Any(x => x.MaterialInStoreObj.Count > 0);
        }
    }
}
