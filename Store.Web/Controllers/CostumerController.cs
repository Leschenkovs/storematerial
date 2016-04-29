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
    [RoutePrefix("api/costumer")]
    public class CostumerController : BaseApiController
    {
        private readonly ICostumerBll _costumerBll;

        public CostumerController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _costumerBll = factoryBll.CostumerBll;
        }

        [Route("api/costumer/GetCostumers")]
        [HttpGet]
        public List<CostumerDTO> GetCostumers([FromUri] QueryRequest queryRequest)
        {
            List<CostumerDTO> costumers = Mapper.Map<IQueryable<Costumer>, List<CostumerDTO>>(_costumerBll.GetAll());
            return costumers;
        }

        [Route("api/costumer/GetCostumersInfoForChart")]
        [HttpGet]
        public List<CostumerInfoForChartDTO> GetCostumersInfoForChart([FromUri] QueryRequest queryRequest)
        {
            List<Costumer> costumers = _costumerBll.GetAll().ToList();

            int year = DateTime.Now.Year;
            List<CostumerInfoForChartDTO> list = new List<CostumerInfoForChartDTO>();

            foreach (Costumer costumer in costumers)
            {
                CostumerInfoForChartDTO obj = new CostumerInfoForChartDTO
                {
                    costumerName = costumer.Name,
                    costs = new List<CostumerCost>()
                };
                for (int i = 1; i < 13; i++)
                {
                    obj.costs.Add(new CostumerCost
                    {
                        month = i,
                        fullCost = costumer.Experses.Where(x => x.AddedDate.Year == year && x.AddedDate.Month == i).Sum(x=>x.FullCost)
                    });
                }
                list.Add(obj);
            }

            return list;
        }


        [HttpGet]
        public CostumerDTO GetCostumer([FromUri] int id)
        {
            CostumerDTO model = Mapper.Map<Costumer, CostumerDTO>(_costumerBll.GetById(id));
            return model;
        }

        [StoreAuthorize(Roles = "admin,read_write")]
        [HttpPost]
        public CostumerDTO CreateCostumer([FromBody] CostumerDTO model)
        {
            Costumer entity = Mapper.Map<CostumerDTO, Costumer>(model);
            model = Mapper.Map<Costumer, CostumerDTO>(_costumerBll.Save(entity));
            return model;
        }

        [StoreAuthorize(Roles = "admin,read_write")]
        [HttpPut]
        public CostumerDTO UpdateCostumer([FromBody] CostumerDTO model)
        {
            Costumer entity = Mapper.Map<CostumerDTO, Costumer>(model);
				model = Mapper.Map<Costumer, CostumerDTO>(_costumerBll.Save(entity)); // AddorUpdate
            return model;
        }

        [StoreAuthorize(Roles = "admin,read_write")]
        [HttpDelete]
        public bool DeleteCostumer([FromUri] int id)
        {
            return _costumerBll.Delete(id);
        }

    }
}