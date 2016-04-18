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

namespace Store.Web.Controllers
{
	[RoutePrefix("api/user")]
	public class UserController : BaseApiController
	{
		private readonly IUserBll _userBll;

		public UserController(IFactoryBll factoryBll)
		{
			if (factoryBll == null)
			{
				throw new ArgumentNullException("factoryBll");
			}
			_userBll = factoryBll.UserBll;
		}

		[HttpGet]
		public List<UserDTO> GetUsers([FromUri]QueryRequest queryRequest)
		{
			Mapper.CreateMap<User, UserDTO>();
			List<UserDTO> users = Mapper.Map<IQueryable<User>, List<UserDTO>>(_userBll.GetAll());

			return users;
		}

		[HttpGet]
		public User GetUser([FromUri]QueryRequest queryRequest)
		{
			return _userBll.GetById(queryRequest.id);
		}

		[HttpPost]
		public User CreateUser([FromBody]QueryRequest<User> queryRequest)
		{
			return _userBll.Add(queryRequest.model);
		}

		[HttpPut]
		public User UpdateUser([FromBody]QueryRequest<User> queryRequest)
		{
			return _userBll.Update(queryRequest.model);
		}

		[HttpDelete]
		public bool DeleteUser([FromBody]QueryRequest queryRequest)
		{
			return _userBll.Delete(queryRequest.id);
		}
	}
}