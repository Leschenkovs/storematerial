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
    //[StoreAuthorize(Roles = "admin,read_write,read")]
    [RoutePrefix("api/kindMaterial")]
    public class KindMaterialController : BaseApiController
    {
        private readonly IKindMaterialBll _kindMaterialBll;

        public KindMaterialController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _kindMaterialBll = factoryBll.KindMaterialBll;
        }

        [HttpGet]
        public List<KindMaterialDTO> GetKindMaterials([FromUri] QueryRequest queryRequest)
        {
            List<KindMaterialDTO> list = Mapper.Map<List<KindMaterial>, List<KindMaterialDTO>>(_kindMaterialBll.GetAll());
            return list;
        }

        [StoreAuthorize(Roles = "admin,read_write")]
        [HttpPost]
        public KindMaterialDTO CreateKindMaterial([FromBody] KindMaterialDTO model)
        {
            KindMaterial entity = Mapper.Map<KindMaterialDTO, KindMaterial>(model);
            entity = _kindMaterialBll.Save(entity, model.unitIds);
            KindMaterialDTO modelToView = Mapper.Map<KindMaterial, KindMaterialDTO>(entity); 
            return modelToView;
        }

        [StoreAuthorize(Roles = "admin,read_write")]
        [HttpPut]
        public KindMaterialDTO UpdateKindMaterial([FromBody] KindMaterialDTO model)
        {
            KindMaterial entity = Mapper.Map<KindMaterialDTO, KindMaterial>(model);
            entity = _kindMaterialBll.Update(entity, model.unitIds);
            model = Mapper.Map<KindMaterial, KindMaterialDTO>(entity);
            return model;
        }

        [StoreAuthorize(Roles = "admin,read_write")]
        [HttpDelete]
        public bool DeleteKindMaterial([FromUri] int id)
        {
            bool entityReuslt = _kindMaterialBll.Delete(id);
            return entityReuslt;
        }
    }
}