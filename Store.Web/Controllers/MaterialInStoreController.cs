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
    [RoutePrefix("api/materialInStore")]
    public class MaterialInStoreController: BaseApiController
    {
        private readonly IMaterialInStoreBll _materialInStoreBll;

        public MaterialInStoreController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _materialInStoreBll = factoryBll.MaterialInStoreBll;
        }

        [HttpGet]
        public List<MaterialInStoreDTO> GetMaterialInStores([FromUri] QueryRequest queryRequest)
        {
            List<MaterialInStoreDTO> list = Mapper.Map<IQueryable<MaterialInStore>, List<MaterialInStoreDTO>>(_materialInStoreBll.GetAll());
            return list;
        }

    }
}