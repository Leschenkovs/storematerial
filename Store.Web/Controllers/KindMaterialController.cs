using System;
using System.Web.Http;
using Store.Bll;
using Store.Bll.Bll;

namespace Store.Web.Controllers
{
    [RoutePrefix("api/kindMaterial")]
    public class KindMaterialController : BaseApiController
    {
        private readonly IKindMaterialBll _kindMaterialBll;

         public KindMaterialController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _kindMaterialBll = factoryBll.KindMaterialBll;
        }
    }
}