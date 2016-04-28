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

        [HttpGet]
        public List<MaterialInStoreCountSupplyAndExperseDTO> GetSupplyAndExperseInfo([FromUri] int materialInStoreId)
        {
            int year = DateTime.Now.Year;
            List<MaterialInStoreCountSupplyAndExperseDTO> list = new List<MaterialInStoreCountSupplyAndExperseDTO>();
            MaterialInStore model = _materialInStoreBll.GetById(materialInStoreId);
            for (int i = 1; i <= 12; i++)
            {
                MaterialInStoreCountSupplyAndExperseDTO obj = new MaterialInStoreCountSupplyAndExperseDTO
                {
                    month = i,
                    experse = model.Experses.Where(x=>x.AddedDate.Year == year && x.AddedDate.Month == i).Sum(x=>x.Count),
                    supply = model.Supplies.Where(x => x.AddedDate.Year == year && x.AddedDate.Month == i).Sum(x => x.Count)
                };
                list.Add(obj);
            }

            return list.OrderBy(x=>x.month).ToList();
        }


    }
}