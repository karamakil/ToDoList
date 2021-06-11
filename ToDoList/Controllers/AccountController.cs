using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.BLL.Interface;
using ToDoList.BLL.Manager;
using ToDoList.BLL.Models;

namespace ToDoList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService tokenService;

        #region ctor
        public AccountController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }
        #endregion

        #region Login

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserModel> Login(UserModel userModel)
        {
            try
            {
                var user = UserManager.Find(userModel.UserName, userModel.Password);
                if (user == null) return Unauthorized("Invaled Credientials");
                return new UserModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Password = user.Password,
                    Token = this.tokenService.CreateToken(user),
                };
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        #endregion

    }
}
