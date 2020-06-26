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

namespace FMSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly fmsContext _context;
        private readonly CourseService _courseService;

        public CoursesController(fmsContext context, CourseService courseService)
        {
            _context = context;
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult GetCoursesById(int id) => Ok(_courseService.GetCoursesById(id));

        [HttpGet]
        public IActionResult GetCoursesByTitle(string title) => Ok(_courseService.GetCoursesByTitle(title));

        [HttpPost]
        public IActionResult AddCourse(string title, int cost, int classhour) => Ok(_courseService.AddCourse(title, cost, classhour));

        [HttpDelete]
        public IActionResult DeleteCourse(int id) => Ok(_courseService.DeleteCourse(id));

        [HttpPut]
        public IActionResult UpdateCourse(Course course) => Ok(_courseService.UpdateCourse(course));
    }
}
