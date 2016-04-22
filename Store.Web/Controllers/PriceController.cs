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
    [RoutePrefix("api/price")]
    public class PriceController : BaseApiController
    {
        private readonly IPriceBll _priceBll;

        public PriceController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _priceBll = factoryBll.PriceBll;
        }

		  [HttpGet]
		  public List<PriceDTO> GetAllPrices([FromUri] QueryRequest queryRequest)
		  {
			 List<PriceDTO> list = Mapper.Map<IQueryable<Price>, List<PriceDTO>>(_priceBll.GetAll());
			 return list;
		  }

		  [HttpGet]
		  public List<PriceDTO> GetPricesByMaterialId([FromUri] int id)
		  {
			 List<PriceDTO> list = Mapper.Map<IList<Price>, List<PriceDTO>>(_priceBll.GetByMaterialInStoreId(id));
			 return list;
		  }

		  [HttpPost]
		  public PriceDTO CreatePrice([FromBody] PriceDTO model)
		  {
			 Price entity = Mapper.Map<PriceDTO, Price>(model);
			 model = Mapper.Map<Price, PriceDTO>(_priceBll.Add(entity));
			 return model;
		  }

          [HttpDelete]
          public bool DeletePrice([FromUri] int id)
          {
              return _priceBll.Delete(id);
          }
    }
}