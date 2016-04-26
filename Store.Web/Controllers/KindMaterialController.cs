using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Store.Bll;
using Store.Bll.Bll;
using Store.Model;
using Store.Model.DTOObjects;
using Store.Model.RequestObjects;
using Store.Web.Attributes;

namespace Store.Web.Controllers
{
    [StoreAuthorize(Roles = "admin,read_write,read")]
    [RoutePrefix("api/kindMaterial")]
    public class KindMaterialController : BaseApiController
    {
        private readonly IKindMaterialBll _kindMaterialBll;
        private readonly IUnitMaterialBll _unitMaterialBll;

        public KindMaterialController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _kindMaterialBll = factoryBll.KindMaterialBll;
            _unitMaterialBll = factoryBll.UnitMaterialBll;
        }

        [HttpGet]
        public List<KindMaterialDTO> GetKindMaterials([FromUri] QueryRequest queryRequest)
        {
            List<KindMaterialDTO> list = Mapper.Map<List<KindMaterial>, List<KindMaterialDTO>>(_kindMaterialBll.GetAll());
            return list;
        }

        [HttpPost]
        public KindMaterialDTO CreateKindMaterial([FromBody] CreateKindMaterialDTO model)
        {
            KindMaterial entity = Mapper.Map<CreateKindMaterialDTO, KindMaterial>(model);
            entity = _kindMaterialBll.Save(entity); // save kindMaterial
            foreach (int idUnit in model.units)
            {
                UnitMaterial obj = new UnitMaterial{KindMaterialId = entity.Id, UnitId = idUnit};
                _unitMaterialBll.Save(obj); // save UnitMaterials
            }

            KindMaterialDTO modelToView = Mapper.Map<KindMaterial, KindMaterialDTO>(_kindMaterialBll.GetById(entity.Id)); // get new kindMaterial with units
            return modelToView;
        }

        [HttpPut]
        public KindMaterialDTO UpdateKindMaterial([FromBody] KindMaterialDTO model)
        {
            KindMaterial entity = Mapper.Map<KindMaterialDTO, KindMaterial>(model);
            model = Mapper.Map<KindMaterial, KindMaterialDTO>(_kindMaterialBll.Save(entity));
            return model;
        }

        [HttpDelete]
        public bool DeleteKindMaterial([FromUri] int id)
        {
            bool entityReuslt = _kindMaterialBll.Delete(id);
            return entityReuslt;
        }
    }
}