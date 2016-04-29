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
    //[StoreAuthorize(Roles = "admin,read_write,read")]
    [RoutePrefix("api/supply")]
    public class SupplyController : BaseApiController
    {
        private readonly ISupplyBll _supplyBll;

        public SupplyController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _supplyBll = factoryBll.SupplyBll;
        }

        [HttpGet]
        public List<SupplyDTO> GetSupplies([FromUri] QueryRequest queryRequest)
        {
            List<SupplyDTO> list = Mapper.Map<IQueryable<Supply>, List<SupplyDTO>>(_supplyBll.GetAll());
            return list;
        }

        [StoreAuthorize(Roles = "admin,read_write")]
        [HttpPost]
        public bool CreateSupply([FromBody] CreateSupplyDTO model)
        {
            bool entityReuslt = _supplyBll.Save(Mapper.Map<CreateSupplyDTO, Supply>(model));
            return entityReuslt;
        }

        [StoreAuthorize(Roles = "admin,read_write")]
        [HttpDelete]
        public bool DeleteSupply([FromUri] int id)
        {
            bool entityReuslt = _supplyBll.Delete(id);
            return entityReuslt;
        }
    }
}