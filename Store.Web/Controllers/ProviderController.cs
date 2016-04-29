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
    [RoutePrefix("api/provider")]
    public class ProviderController: BaseApiController
    {
        private readonly IProviderBll _providerBll;

        public ProviderController(IFactoryBll factoryBll)
		{
			if (factoryBll == null)
			{
				throw new ArgumentNullException("factoryBll");
			}
            _providerBll = factoryBll.ProviderBll;
		}

        [HttpGet]
        public List<ProviderDTO> GetProviders([FromUri]QueryRequest queryRequest)
        {
            List<ProviderDTO> providers = Mapper.Map<IQueryable<Provider>, List<ProviderDTO>>(_providerBll.GetAll());
            return providers;
        }

        [HttpGet]
        public ProviderDTO GetProvider([FromUri]int id)
        {
            ProviderDTO model = Mapper.Map<Provider,ProviderDTO>(_providerBll.GetById(id));
            return model;
        }

        [StoreAuthorize(Roles = "admin,read_write")]
        [HttpPost]
        public ProviderDTO CreateProvider([FromBody]ProviderDTO model)
        {
            Provider entity = Mapper.Map<ProviderDTO, Provider>(model);
            model = Mapper.Map<Provider, ProviderDTO>(_providerBll.Save(entity));
            return model;
        }

        [StoreAuthorize(Roles = "admin,read_write")]
        [HttpPut]
        public ProviderDTO UpdateProvider([FromBody]ProviderDTO model)
        {
            Provider entity = Mapper.Map<ProviderDTO, Provider>(model);
            model = Mapper.Map<Provider, ProviderDTO>(_providerBll.Save(entity)); // AddorUpdate
            return model;
        }

        [StoreAuthorize(Roles = "admin,read_write")]
        [HttpDelete]
        public bool DeleteProvider([FromUri]int id)
        {
            return _providerBll.Delete(id);
        }

    }
}