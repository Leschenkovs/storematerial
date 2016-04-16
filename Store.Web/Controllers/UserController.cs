using System;
using System.Collections.Generic;
using System.Web.Http;
using Store.Bll.Bll;
using Store.Model;

namespace Store.Web.Controllers
{
	[RoutePrefix("api/User")]
	public class UserController : BaseApiController
	{
		private readonly IUserBll _userBll;

		public UserController(IUserBll userBll)
		{
			if (userBll == null)
			{
				throw new ArgumentNullException("userBll");
			}
			_userBll = userBll;
		}

		[HttpGet]
		public List<User> GetUsers()
		{
			return new List<User>();
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