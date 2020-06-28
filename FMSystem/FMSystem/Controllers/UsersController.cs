﻿using System;
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
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
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
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            context.Entry(user).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserCreateModel usermodel)
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

        private bool UserExists(long id)
        {
            return context.User.Any(e => e.UserId == id);
        }
    }
}
