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
		public IList<User> GetUsers()
		{
			return _userBll.GetAll();
		}

		[HttpGet]
		public User GetUser(string tn)
		{
			return _userBll.GetByTn(tn);
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