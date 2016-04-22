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

        [HttpGet]
        public List<CostumerDTO> GetCostumers([FromUri] QueryRequest queryRequest)
        {
            List<CostumerDTO> costumers = Mapper.Map<IQueryable<Costumer>, List<CostumerDTO>>(_costumerBll.GetAll());
            return costumers;
        }

        [HttpGet]
        public CostumerDTO GetCostumer([FromUri] int id)
        {
            CostumerDTO model = Mapper.Map<Costumer, CostumerDTO>(_costumerBll.GetById(id));
            return model;
        }

        [HttpPost]
        public CostumerDTO CreateCostumer([FromBody] CostumerDTO model)
        {
            Costumer entity = Mapper.Map<CostumerDTO, Costumer>(model);
            model = Mapper.Map<Costumer, CostumerDTO>(_costumerBll.Save(entity));
            return model;
        }

        [HttpPut]
        public CostumerDTO UpdateCostumer([FromBody] CostumerDTO model)
        {
            Costumer entity = Mapper.Map<CostumerDTO, Costumer>(model);
				model = Mapper.Map<Costumer, CostumerDTO>(_costumerBll.Save(entity)); // AddorUpdate
            return model;
        }

        [HttpDelete]
        public bool DeleteCostumer([FromUri] int id)
        {
            return _costumerBll.Delete(id);
        }

    }
}