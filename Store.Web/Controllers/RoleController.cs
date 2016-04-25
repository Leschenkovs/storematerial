using System;
using System.Collections.Generic;
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
    [RoutePrefix("api/role")]
    public class RoleController : BaseApiController
    {
        private readonly IRoleBll _roleBll;

        public RoleController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _roleBll = factoryBll.RoleBll;
        }

        [HttpGet]
        public List<RoleDTO> GetRoles([FromUri]QueryRequest queryRequest)
        {
            Mapper.CreateMap<Role, RoleDTO>();
            List<RoleDTO> roles = Mapper.Map<List<Role>, List<RoleDTO>>(_roleBll.GetAll());
            return roles;
        }
    }
}