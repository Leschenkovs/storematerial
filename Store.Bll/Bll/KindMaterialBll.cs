using System;
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
        KindMaterial Save(KindMaterial entity, int[] unitIds);
        KindMaterial Update(KindMaterial entity, int[] unitIds);
        new bool Delete(int id);
    }

    public class KindMaterialBll : BaseBll<KindMaterial, IKindMaterialDal>, IKindMaterialBll
    {
        private IUnitMaterialBll _unitMaterialBll;
        protected IFactoryDal FactoryDal;

        public KindMaterialBll(IFactoryDal factoryDal, IUnitMaterialBll unitMaterialBll)
            : base(factoryDal.KindMaterialDal)
        {
            FactoryDal = factoryDal;
            _unitMaterialBll = unitMaterialBll;
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
            foreach (UnitMaterial unitMaterial in entity.UnitMaterials.Where(um => !unitIds.Contains(um.UnitId)))
            {
                if (IsExistUnitMaterialInSotreByUnitMaterial(unitMaterial.Id))
                {
                    throw new DbOwnException(String.Format(
                            "На складе имеются остатки материала '{0}', использующие единицу измереия '{1}', удаление не возможно!",
                            unitMaterial.KindMaterialObj.Name, unitMaterial.UnitObj.ShortName));
                }
                _unitMaterialBll.Delete(unitMaterial.Id);
            }
            // Add new UnitMaterial
            foreach (int unitId in unitIds.Where(unitId => entity.UnitMaterials.All(x => x.UnitId != unitId)))
            {
                entity.UnitMaterials.Add(GetNewUnitMaterial(unitId));
            }
            Save(entity);
            entity = GetById(model.Id);
            
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
            bool isExistMaterialInStore = IsExistMaterialInStoreByKindMaterialId(id);
            if (isExistMaterialInStore)
            {
                throw new DbOwnException("На складе имеются остатки этого материала, удаление не возможно!");
            }
            return base.Delete(id);
        }

        private bool IsExistMaterialInStoreByKindMaterialId(int id)
        {
            KindMaterial model = GetById(id);
            return model != null && model.UnitMaterials.Any(x => x.MaterialInStoreObj != null && x.MaterialInStoreObj.Count > 0);
        }

        private bool IsExistUnitMaterialInSotreByUnitMaterial(int unitMaterial)
        {
            MaterialInStore model = FactoryDal.MaterialInStoreDal.GetAll().FirstOrDefault(x => x.UnitMaterialId == unitMaterial);
            return model != null && model.Count != 0;
        }
    }
}
