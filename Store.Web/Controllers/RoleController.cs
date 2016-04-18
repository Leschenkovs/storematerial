using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Store.Bll;
using Store.Bll.Bll;
using Store.Model;
using Store.Model.DTOObjects;

namespace Store.Web.Controllers
{
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
	 public List<RoleDTO> GetRoles()
	 {
		Mapper.CreateMap<Role, RoleDTO>();
		List<RoleDTO> roles = Mapper.Map<IQueryable<Role>, List<RoleDTO>>(_roleBll.GetAll());

		return roles;
	 }

  }
}