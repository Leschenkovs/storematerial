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
    [RoutePrefix("api/experse")]
    public class ExperseController : BaseApiController
    {
        private readonly IExperseBll _experseBll;
        private readonly IMaterialInStoreBll _materialInStoreBll;

        public ExperseController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _experseBll = factoryBll.ExperseBll;
            _materialInStoreBll = factoryBll.MaterialInStoreBll;
        }

        [HttpGet]
        public List<ExperseDTO> GetSupplies([FromUri] QueryRequest queryRequest)
        {
            List<ExperseDTO> list = Mapper.Map<IQueryable<Experse>, List<ExperseDTO>>(_experseBll.GetAll());
            return list;
        }


        [HttpGet]
        public CreateExperseDTO GetCreateExperse([FromUri] int materialInStoreId)
        {
            CreateExperseDTO model = Mapper.Map<CreateExperseDTO>(_materialInStoreBll.GetById(materialInStoreId));
            return model;
        }

        [HttpPost]
        public bool CreateExperse([FromBody] CreateExperseDTO model)
        {
            bool entityReuslt = _experseBll.Save(Mapper.Map<CreateExperseDTO, Experse>(model));
            return entityReuslt;
        }

    }
}