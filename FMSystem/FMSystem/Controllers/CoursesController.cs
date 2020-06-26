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

namespace FMSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly fmsContext _context;
        private readonly CourseService _courseService;
        private readonly IMapper mapper;

        public CoursesController(fmsContext context, CourseService courseService, IMapper mapper)
        {
            _context = context;
            _courseService = courseService;
            this.mapper = mapper;
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
        /// Update course if exist, Add it if not exist
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
    }
}
