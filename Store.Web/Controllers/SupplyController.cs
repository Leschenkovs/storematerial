using System;
using System.Web.Http;
using Store.Bll;
using Store.Bll.Bll;

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

    }
}