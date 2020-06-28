using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using FMSystem.Controllers.Binder;
using FMSystem.Entity;
using FMSystem.Entity.fms;
using FMSystem.Extensions;
using FMSystem.Models;
using FMSystem.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Controllers
{

    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OauthController : ControllerBase
    {

        private readonly fmsContext _context;
        private readonly IMapper mapper;
        public OauthController(fmsContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// post 登录请求
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] JsonElement userjobj)
        {
            long UserId = long.Parse(userjobj.GetProperty(nameof(UserId)).GetString());
            string Password = userjobj.GetProperty(nameof(Password)).GetString();
            var response = new ResponseModel();

            var User = _context.User.SingleOrDefault(u => u.UserId == UserId);
            if (User != null && User.Password == Password)
            {

                var claims = new List<Claim>(){
                    new Claim("Id",UserId.ToString()),
                    new Claim(ClaimTypes.Name,User.UserName),
                    new Claim("UserRole",((int)User.Role).ToString()),
                    new Claim("Number",User.Number.ToString())
                };

                var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Customer"));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });
                response.SetSuccess();
                response.SetData(mapper.Map<UserViewModel>(User));
                return Ok(response);
            }
            response.SetFailed("用户名或密码错误");
            return Ok(response);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var r = new ResponseModel();
            r.SetSuccess();
            return Ok(r);

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
        [HttpGet]
        public IActionResult AccessDenied()
        {
            ResponseModel response = new ResponseModel();
            response.SetFailed("未登陆");
            response.Code = 401;
            return Ok(response);
        }
    }

}
