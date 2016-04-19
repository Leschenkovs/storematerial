using System;
using System.Web.Http;
using Store.Bll;
using Store.Bll.Bll;

namespace Store.Web.Controllers
{
    [RoutePrefix("api/price")]
    public class PriceController
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
    }
}