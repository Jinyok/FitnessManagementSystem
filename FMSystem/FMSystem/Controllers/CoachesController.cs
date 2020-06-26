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
using FMSystem.Interface;
using FMSystem.Service;

namespace FMSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private readonly fmsContext _context;
        private readonly CoachService _coachService;

        public CoachesController(fmsContext context, CoachService coachService)
        {
            _context = context;
            _coachService = coachService;
        }

        [HttpGet]
        public IActionResult GetCoachesById(int id) => Ok(_coachService.GetCoachesById(id));

        [HttpGet]
        public IActionResult GetCoachesByName(string name) => Ok(_coachService.GetCoachesByName(name));

        [HttpPost]
        public IActionResult AddCoach(string name, long phoneno, string email) => Ok(_coachService.AddCoach(name, phoneno, email));

        [HttpDelete]
        public IActionResult DeleteCoach(int id) => Ok(_coachService.DeleteCoach(id));

        [HttpPut]
        public IActionResult UpdateCoach(Coach coach) => Ok(_coachService.UpdateCoach(coach));
    }
}
