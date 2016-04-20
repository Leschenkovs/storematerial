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

namespace Store.Web.Controllers
{
    [RoutePrefix("api/unit")]
    public class UnitController : BaseApiController
    {
        private readonly IUnitBll _unitBll;

        public UnitController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _unitBll = factoryBll.UnitBll;
        }

        [HttpGet]
        public List<UnitDTO> GetUnits([FromUri]QueryRequest queryRequest)
        {
            Mapper.CreateMap<Unit, UnitDTO>();
            List<UnitDTO> units = Mapper.Map<IQueryable<Unit>, List<UnitDTO>>(_unitBll.GetAll());

            return units;
        }
    }
}