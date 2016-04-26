using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
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
        KindMaterial Save(KindMaterial entity, int[] unitIds);
        KindMaterial Update(KindMaterial entity, int[] unitIds);
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

        public KindMaterial Save(KindMaterial entity, int[] unitIds)
        {
            CacheHelper.CleanCache(GlobalConstants.KindMaterialsKey);

            KindMaterial newEntity = Create();
            newEntity.Name = entity.Name;
            newEntity.Articul = entity.Articul;

            foreach (int idUnit in unitIds)
            {
                newEntity.UnitMaterials.Add(GetNewUnitMaterial(idUnit));
            }
            Save(newEntity);

            return newEntity;
        }

        public KindMaterial Update(KindMaterial model, int[] unitIds)
        {
            CacheHelper.CleanCache(GlobalConstants.KindMaterialsKey);

            // Save only properties
            Save(model);
            KindMaterial entity = GetById(model.Id);

            // Remove old UnitMaterial
            int[] idsForDelete = entity.UnitMaterials.Where(um => !unitIds.Contains(um.UnitId)).Select(x => x.Id).ToArray();
            foreach (int i in idsForDelete)
            {
                entity.UnitMaterials.Remove(entity.UnitMaterials.First(x => x.Id == i));
            }

            //foreach (UnitMaterial unitMaterial in entity.UnitMaterials.Where(um => !unitIds.Contains(um.UnitId)).ToArray())
            //{
            //    entity.UnitMaterials.Remove(unitMaterial);
            //}
            // Add new UnitMaterial
            foreach (int unitId in unitIds.Where(unitId => entity.UnitMaterials.All(x => x.UnitId != unitId)))
            {
                entity.UnitMaterials.Add(GetNewUnitMaterial(unitId));
            }
            Save(entity);
            return entity;
        }

        private UnitMaterial GetNewUnitMaterial(int id)
        {
            UnitMaterial unitMaterial = FactoryDal.UnitMaterialDal.Create();
            unitMaterial.UnitId = id;
            return unitMaterial;
        }

        public new bool Delete(int id)
        {
            bool isExistMaterialInStore = IsExistMaterialInStore(id);
            if (isExistMaterialInStore) { throw new DbOwnException("На складе имеются остатки этого материала, удаление не возможно!"); }
            return base.Delete(id);
        }

        private bool IsExistMaterialInStore(int id)
        {
            KindMaterial model = GetById(id);
            return model != null && model.UnitMaterials.Any(x => x.MaterialInStoreObj != null && x.MaterialInStoreObj.Count > 0);
        }
    }
}
