using System.Linq;
using System.Security.Principal;
using System.Web.Http;
using Store.Bll.Exception;

namespace Store.Web.Attributes
{
    public class StoreAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (AuthorizeRequest(actionContext))
            {
                return;
            }
            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            throw new DbOwnException("У вас недостаточно прав!");
        }

        private bool AuthorizeRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            IPrincipal principal = actionContext.RequestContext.Principal;
            if (principal.Identity.IsAuthenticated)
            {
                return Roles.Split(',').Any(role => principal.IsInRole(role.Trim()));
            }
            return false;
        }
    }
}