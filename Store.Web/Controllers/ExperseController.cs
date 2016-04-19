using System;
using System.Web.Http;
using Store.Bll;
using Store.Bll.Bll;

namespace Store.Web.Controllers
{
    [RoutePrefix("api/experse")]
    public class ExperseController : BaseApiController
    {
        private readonly IExperseBll _experseBll;

        public ExperseController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _experseBll = factoryBll.ExperseBll;
        }
    }
}