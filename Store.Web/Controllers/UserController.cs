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
		public List<UserDTO> GetUsers()
		{
		  Mapper.CreateMap<User, UserDTO>();
		  List<UserDTO> users = Mapper.Map<IQueryable<User>, List<UserDTO>>(_userBll.GetAll());

		  return users;
		}

		[HttpGet]
		public User GetUser(int id)
		{
			return _userBll.GetById(id);
		}

		[HttpPost]
		public User CreateUser(User entity)
		{
			return _userBll.Add(entity);
		}

		[HttpPut]
		public User UpdateUser(User entity)
		{
			return _userBll.Update(entity);
		}

		[HttpDelete]
		public bool DeleteUser(int id)
		{
			return _userBll.Delete(id);
		}
	}
}