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
    public class CoachesController : ControllerBase
    {
        private readonly fmsContext _context;
        private readonly CoachService _coachService;
        private readonly IMapper mapper;

        public CoachesController(fmsContext context, CoachService coachService, IMapper mapper)
        {
            _context = context;
            _coachService = coachService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCoachesById(int id) => Ok(_coachService.GetCoachesById(id));

        [HttpGet]
        public IActionResult GetCoachesByName(string name) => Ok(_coachService.GetCoachesByName(name));

        [HttpPost]
        public IActionResult AddCoach(CoachViewModel coach) => Ok(_coachService.AddCoach(coach.Name, coach.PhoneNo, coach.Email));

        [HttpDelete]
        public IActionResult DeleteCoach(int id) => Ok(_coachService.DeleteCoach(id));

        [HttpPut]
        public IActionResult UpdateCoach([Bind("CoachId Name PhoneNo")] CoachViewModel coach) => Ok(_coachService.UpdateCoach(coach));

        [HttpGet]
        public async Task<IActionResult> GetCoaches()
        {
            var response = new ResponseModel();
            var list = await _context.Coach.ToListAsync();
            if (list.Count == 0)
                response.SetFailed("无教练");
            else
            {
                var viewmodels = mapper.Map<List<CoachViewModel>>(list);
                foreach (var x in viewmodels)
                    x.PhoneNo = x.PhoneNo.FormatPhoneNo();
                response.SetSuccess();
                response.SetData(viewmodels);
            }
            return Ok(response);
        }

    }
}
