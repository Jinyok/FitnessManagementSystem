using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FMSystem.Entity;
using FMSystem.Entity.fms;
using FMSystem.Service;
using FMSystem.ViewModels;
using AutoMapper;
using FMSystem.Models;
using Microsoft.Extensions.Logging;

namespace FMSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly fmsContext _context;
        private readonly CourseService _courseService;
        private readonly IMapper mapper;
        private readonly ILogger<CoursesController> logger;

        public CoursesController(fmsContext context, CourseService courseService, IMapper mapper,ILogger<CoursesController> logger)
        {
            _context = context;
            _courseService = courseService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetCoursesById(int id) => Ok(_courseService.GetCoursesById(id));

        [HttpGet]
        public IActionResult GetCoursesByTitle(string title) => Ok(_courseService.GetCoursesByTitle(title));

        [HttpPost]
        public IActionResult AddCourse(CourseViewModel course) => Ok(_courseService.AddCourse(course.Title, course.Cost, course.ClassHour));

        [HttpDelete]
        public IActionResult DeleteCourse(int id) => Ok(_courseService.DeleteCourse(id));

        /// <summary>
        /// Update course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateCourse(CourseViewModel course)
        {
            var response = new ResponseModel();
            Course _course = mapper.Map<Course>(course);
            if (_course.CourseId > 0)
            {
                _context.Course.Update(_course);
                _context.SaveChanges();
                response.SetSuccess();
            }
            else
            {
                response.SetFailed("CourseId 必须大于0");
            }
            return Ok(response);

        }

        [HttpGet]
        public IActionResult GetPersonalCoursesByCoachId(int CoachId)
        {
            var response = new ResponseModel();
            var PersonalCourses = _context.Instructs.AsNoTracking()
                .Where(t => t.CoachId == CoachId)
                .Select(t => new
                {
                    t.MemberId,
                    t.Member.Name,
                    t.Member.PhoneNo,
                    t.TotalHours,
                    t.AttendedHours
                }).ToList();
            if (PersonalCourses.Count == 0)
            {
                response.SetFailed("教练无私教课程");
                return Ok(response);
            }
            response.SetData(new { Members = PersonalCourses });
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddPersonalCourse(PersonalCourseViewModel model)
        {
            var response = new ResponseModel();
            model.AttendedHours = 0;
            var instruct = mapper.Map<Instructs>(model);
            _context.Add(instruct);
            try
            {
                _context.SaveChanges();
                response.SetSuccess();
            }
            catch (DbUpdateException)
            {
                if (!_context.Course.Any(e => e.CourseId == instruct.CoachId))
                    response.SetFailed("教练Id不存在");
                else if (!_context.Member.Any(e => e.MemberId == instruct.MemberId))
                    response.SetFailed("会员Id不存在");
                response.SetFailed();
            }
            return Ok(response);
        }
        [HttpDelete]
        public IActionResult DeletePersonalCourse(int MemberId, int CoachId)
        {
            var response = new ResponseModel();
            var instructs = _context.Instructs.Single(e => e.MemberId == MemberId && e.CoachId == CoachId);
            if (instructs == null)
            {
                response.SetFailed("私教课程不存在");
                return Ok(response);
            }
            _context.Remove(instructs);
            _context.SaveChanges();
            response.SetSuccess();
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdatePersonalCourse(PersonalCourseViewModel model)
        {
            var response = new ResponseModel();
            var personalCourse = mapper.Map<Instructs>(model);
            _context.Instructs.Update(personalCourse);
            try
            {
                _context.SaveChanges();
                response.SetSuccess();
            }
            catch (DbUpdateException e)
            {
                if (!_context.Instructs.Any(e => e.MemberId == model.MemberId && e.CoachId == model.CoachId))
                    response.SetFailed($"私教课程不存在, MemberId:{model.MemberId}, CoachId:{model.CoachId}");
                else
                {
                    response.SetFailed();
                    logger.LogError(e.Message);
                }
                    
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var response = new ResponseModel();
            var list = await _context.Course.ToListAsync();
            if (list.Count == 0)
                response.SetFailed("无课程");
            else
            {
                var viewmodels = mapper.Map<List<CourseViewModel>>(list);
                response.SetSuccess();
                response.SetData(viewmodels);
            }
            return Ok(response);
        }
    }
}
