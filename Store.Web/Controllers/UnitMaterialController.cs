using System;
using System.Collections.Generic;
using System.Linq;
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
    [RoutePrefix("api/unitMaterial")]
    public class UnitMaterialController : BaseApiController
    {
        private readonly IUnitMaterialBll _unitMaterialBll;

        public UnitMaterialController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _unitMaterialBll = factoryBll.UnitMaterialBll;
        }

        [HttpGet]
        public List<UnitMaterialDTO> GetKindMaterials([FromUri] QueryRequest queryRequest)
        {
            List<UnitMaterialDTO> list = Mapper.Map<IQueryable<UnitMaterial>, List<UnitMaterialDTO>>(_unitMaterialBll.GetAll());
            return list;
        }

        [HttpGet]
        public List<UnitMaterialDTO> GetUnitByKindMaterialId([FromUri] int id)
        {
            List<UnitMaterialDTO> list = Mapper.Map<IList<UnitMaterial>, List<UnitMaterialDTO>>(_unitMaterialBll.GetByKindMaterialId(id));
            return list;
        }

        [HttpPost]
        public UnitMaterialDTO CreateUnitMaterial([FromBody] UnitMaterialDTO model)
        {
            UnitMaterial entity = Mapper.Map<UnitMaterialDTO, UnitMaterial>(model);
            model = Mapper.Map<UnitMaterial, UnitMaterialDTO>(_unitMaterialBll.Save(entity));
            return model;
        }

        [HttpDelete]
        public bool DeleteUnitMaterial([FromUri] int id)
        {
            return _unitMaterialBll.Delete(id);
        }
    }
}