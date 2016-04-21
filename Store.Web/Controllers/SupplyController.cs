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
        private readonly IMaterialInStoreBll _materialInStoreBll;

        public SupplyController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _supplyBll = factoryBll.SupplyBll;
            _materialInStoreBll = factoryBll.MaterialInStoreBll;
        }

		  [HttpGet]
		  public List<SupplyDTO> GetSupplies([FromUri] QueryRequest queryRequest)
		  {
			 List<SupplyDTO> list = Mapper.Map<IQueryable<Supply>, List<SupplyDTO>>(_supplyBll.GetAll());
			 return list;
		  }

		  [HttpPost]
          public Supply CreateSupply([FromBody] CreateSupplyDTO model)
		  {
		      MaterialInStore objMaterial = Mapper.Map<CreateSupplyDTO, MaterialInStore>(model);
              objMaterial = _materialInStoreBll.Save(objMaterial);
              if (objMaterial == null) { throw new DbOwnException("Ошибка добавления записи о материале на склад!"); }
              Supply objSupply = _supplyBll.Save(Mapper.Map<CreateSupplyDTO, Supply>(model));

              return objSupply;
		  }

          [HttpDelete]
          public bool DeleteSupply([FromUri] int id)
          {
              bool entityReuslt = _supplyBll.Delete(id);
              return entityReuslt;
          }
    }
}