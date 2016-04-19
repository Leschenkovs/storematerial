using System;
using System.Web.Http;
using Store.Bll;
using Store.Bll.Bll;

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
    }
}