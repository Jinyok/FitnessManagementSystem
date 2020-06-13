using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using FMSystem.Controllers.Binder;
using FMSystem.Extensions;
using FMSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Server.Controllers
{

    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OauthController : ControllerBase

    {
        /// <summary>
        /// post 登录请求
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([ModelBinder(typeof(BodyFormModelBinder))] User user)
        {
            string username = user.UserName;
            string password = user.Password;
            if (username == null || password == null)
                return Ok(new { result = false, msg = $"{username} {password}" });

            if (username.Equals("admin") && password.Equals("123456"))
            {

                var claims = new List<Claim>(){
                    new Claim("Id",0.ToString()),
                    new Claim(ClaimTypes.Name,username),
                    new Claim("UserRole",((int)FMSystem.Models.User.UserRole.Root).ToString())

                };

                var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Customer"));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

                return Redirect("/Home/Index");
            }
            return Ok(new { result = false, msg = "用户名密码错误!" });
        }

        [HttpPost, Authorize]
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Home/Login");

        }
        [HttpGet]
        [Authorize]
        public ActionResult<User> Authtest()
        {
            return AuthContext.CurrentUser;
        }
        //public FileResult excel()
        //{
        //    var s = System.IO.File.OpenRead("E:/html/DncZeus-2.0.0.1/DncZeus.App/src/config/index.js");
        //    return File(s, "text/plain", "hh.txt");
        //}

    }

}
