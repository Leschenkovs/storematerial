using System;
using System.Collections.Generic;
using System.Web.Http;
using Store.Bll;
using Store.Bll.Bll;
using Store.Model;

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
		public List<User> GetUsers()
		{
			List<User> a = new List<User>();
			a.Add(new User{ Tn = "aaa", Fio = "Test"});
			return a;
		}

		[HttpGet]
		public User GetUser(int id)
		{
			return new User();
		}

		[HttpPost]
		public User CreateUser(User entity)
		{
			return new User();
		}

		[HttpPut]
		public User UpdateUser(User entity)
		{
			return new User();
		}

		[HttpDelete]
		public bool DeleteUser(int id)
		{
			return true;
		}
	}
}