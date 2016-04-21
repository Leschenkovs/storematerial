using System;
using System.Web.Http;
using AutoMapper;
using Store.Bll;
using Store.Bll.Bll;
using Store.Model;
using Store.Model.DTOObjects;
using Store.Model.RequestObjects;

namespace Store.Web.Controllers
{
    [RoutePrefix("api/authentication")]
    public class AuthenticationController : ApiController
    {
        private readonly IUserBll _userBll;

        public AuthenticationController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _userBll = factoryBll.UserBll;
        }

        [HttpPost]
        public IHttpActionResult Authenticate([FromBody]AuthenticateRequest request)
        {
            User user = _userBll.GetByTnAndPassword(request.username, request.password);
            if (user == null)
            {
                return Ok(new { success = false, message = "User code or password is incorrect" });
            }
            UserDTO model = Mapper.Map<UserDTO>(user);
            return Ok(new { success = true, user = model });
        }
    }
}