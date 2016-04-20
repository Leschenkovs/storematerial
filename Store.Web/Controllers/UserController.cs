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
            List<UserDTO> users = Mapper.Map<IQueryable<User>, List<UserDTO>>(_userBll.GetAll());
            return users;
        }

        [HttpGet]
        public UserDTO GetUser([FromUri]int id)
        {
            UserDTO model = Mapper.Map<UserDTO>(_userBll.GetById(id));
            return model;
        }

        //[Authorize, ActionName("login")]
        //public UserDTO Login([FromUri]string tn, string psw)
        //{
        //    UserDTO model = Mapper.Map<UserDTO>(_userBll.GetByTnAndPassword(tn, psw));
        //    return model;
        //}

        [HttpPost]
        public UserDTO CreateUser([FromBody]UserDTO model)
        {
            User entity = Mapper.Map<User>(model);
            model = Mapper.Map<UserDTO>(_userBll.Add(entity));
            return model;
        }

        [HttpPut]
        public UserDTO UpdateUser([FromBody]UserDTO model)
        {
            User entity = Mapper.Map<User>(model);
            model = Mapper.Map<UserDTO>(_userBll.Update(entity));
            return model;
        }

        [HttpDelete]
        public bool DeleteUser([FromUri]int id)
        {
            return _userBll.Delete(id);
        }
    }
}