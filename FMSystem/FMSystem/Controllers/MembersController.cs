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
using FMSystem.Interface;
using FMSystem.Service;
using FMSystem.ViewModels;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using AutoMapper;
using FMSystem.Extensions;

namespace FMSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly fmsContext _context;
        private readonly MemberService memberservice;
        private readonly IMapper mapper;

        public MembersController(fmsContext context, MemberService memberservice, IMapper mapper)
        {
            _context = context;
            this.memberservice = memberservice;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMembersById(int id) => Ok(memberservice.GetMembersById(id));

        [HttpGet]
        public IActionResult GetMembersByName(string name) => Ok(memberservice.GetMembersByName(name));

        [HttpPost]
        public IActionResult AddMember(MemberViewModel member) => Ok(memberservice.AddMember(member.PhoneNo,member.Name));

        [HttpDelete]
        public IActionResult DeleteMember(int id) => Ok(memberservice.DeleteMember(id));

        [HttpPut]
        public IActionResult UpdateMember(MemberViewModel coach) => Ok(memberservice.UpdateMember(coach));

        //[HttpGet]
        //public async Task<IActionResult> GetCoaches()
        //{
        //    var response = new ResponseModel();
        //    var list = await _context.Coach.ToListAsync();
        //    if (list.Count == 0)
        //        response.SetFailed("无教练");
        //    else
        //    {
        //        var viewmodels = mapper.Map<List<CoachViewModel>>(list);
        //        foreach (var x in viewmodels)
        //            x.PhoneNo = x.PhoneNo.FormatPhoneNo();
        //        response.SetSuccess();
        //        response.SetData(viewmodels);
        //    }
        //    return Ok(response);
        //}

    }
}
