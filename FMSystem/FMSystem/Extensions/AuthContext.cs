using FMSystem.Entity.fms;
using FMSystem.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FMSystem.Extensions
{
    public static class AuthContext
    {
        static IHttpContextAccessor _context;

        public static HttpContext Current => _context.HttpContext;
        public static void Configure(IHttpContextAccessor accessor)
        {
            AuthContext._context = accessor;
        }

        public static User CurrentUser
        {
            get
            {
                var user = new User();
                user.UserId = Convert.ToInt64(Current.User.FindFirstValue("Id"));
                user.UserName = Current.User.FindFirstValue(ClaimTypes.Name);
                user.Role = (User.UserRole)Convert.ToInt32(Current.User.FindFirstValue("UserRole"));
                return user;
            }
        }
    }
}
