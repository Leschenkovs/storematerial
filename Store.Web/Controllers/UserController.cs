using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Store.Bll;
using Store.Bll.Bll;
using Store.Model;
using Store.Web.ViewModel;

namespace Store.Web.Controllers
{
	[RoutePrefix("api/user")]
	public class UserController : BaseApiController
	{
		private readonly IUserBll _userBll;
        private readonly IRoleBll _roleBll;

		public UserController(IFactoryBll factoryBll)
		{
			if (factoryBll == null)
			{
				throw new ArgumentNullException("factoryBll");
			}
			_userBll = factoryBll.UserBll;
            _roleBll = factoryBll.RoleBll;
		}

		[HttpGet]
        public UserVm GetUsers()
		{
            UserVm model = new UserVm
            {
                Users = _userBll.GetAll().ToList(),
                Roles = _roleBll.GetAll().ToList()
            };
            return model;
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