using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FMSystem.Models;
using FMSystem.Entity;
using FMSystem.Entity.fms;
using AutoMapper;
using FMSystem.ViewModels;

namespace FMSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly fmsContext context;
        private readonly IMapper mapper;

        public UsersController(fmsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var response = new ResponseModel();
            var list = await context.User.ToListAsync();
            if (list.Count == 0)
                response.SetFailed("无会员");
            else
            {
                var viewmodels = mapper.Map<List<UserViewModel>>(list);
                response.SetSuccess();
                response.SetData(viewmodels);
            }
            return Ok(response);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var response = new ResponseModel();
            var user = await context.User.FindAsync(id);

            if (user == null)
            {
                response.SetFailed("未找到用户");
            }
            else
            {
                response.SetData(mapper.Map<UserViewModel>(user));
                response.SetSuccess();
            }
            return Ok(response);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutUser(UserViewModel usermodel)
        {
            var response = new ResponseModel();
            var user = mapper.Map<User>(usermodel);
            context.User.Update(user);
            try
            {
                await context.SaveChangesAsync();
                response.SetSuccess();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(usermodel.UserId))
                {
                    response.SetFailed("用户不存在");
                }
                else
                {
                    throw;
                }
            }

            return Ok(response);
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostUser(UserCreateModel usermodel)
        {
            var response = new ResponseModel();
            var user = mapper.Map<User>(usermodel);
            user.CreateTime = DateTimeOffset.Now;
            context.User.Add(user);
            if (context.User.Any(x => x.Role == FMSystem.Entity.fms.User.UserRole.Coach && x.Role == user.Role && x.Number == user.Number))
            {
                //TODO
                response.SetFailed("对应Number与角色已经存在");
                return Ok(response);
            }
            await context.SaveChangesAsync();
            response.SetSuccess();
            response.SetData(new { user.UserId });
            return Ok(response);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            var user = await context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            context.User.Remove(user);
            await context.SaveChangesAsync();

            return user;
        }

        [HttpGet]
        public IActionResult GetCoachUserByNumber(int number)
        {
            var response = new ResponseModel();
            var user = context.User.SingleOrDefault(e => e.Role == FMSystem.Entity.fms.User.UserRole.Coach && e.Number == number);
            if (user == null)
                response.SetFailed("未找到");
            else
            {
                response.SetSuccess();
                response.SetData(mapper.Map<UserViewModel>(user));
            }
            return Ok(response);
        }

        private bool UserExists(long id)
        {
            return context.User.Any(e => e.UserId == id);
        }
    }
}
