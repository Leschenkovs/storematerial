using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Store.Bll;
using Store.Bll.Bll;
using Store.Bll.Exception;
using Store.Model;
using Store.Model.DTOObjects;
using Store.Model.RequestObjects;

namespace Store.Web.Controllers
{
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

		  [HttpPost]
          public bool CreateSupply([FromBody] CreateSupplyDTO model)
		  {
              bool entityReuslt = _supplyBll.Save(Mapper.Map<CreateSupplyDTO, Supply>(model));
              return entityReuslt;
		  }

          [HttpDelete]
          public bool DeleteSupply([FromUri] int id)
          {
              bool entityReuslt = _supplyBll.Delete(id);
              return entityReuslt;
          }
    }
}