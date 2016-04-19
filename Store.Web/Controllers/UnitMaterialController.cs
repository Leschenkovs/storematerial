using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Store.Bll;
using Store.Bll.Bll;
using Store.Model;
using Store.Model.DTOObjects;

namespace Store.Web.Controllers
{
    [RoutePrefix("api/unit")]
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
        public List<UnitMaterialDTO> GetUnitByKindMaterialId([FromUri] int id)
        {
            List<UnitMaterialDTO> list = Mapper.Map<IList<UnitMaterial>, List<UnitMaterialDTO>>(_unitMaterialBll.GetByKindMaterialId(id));
            return list;
        }

    }
}