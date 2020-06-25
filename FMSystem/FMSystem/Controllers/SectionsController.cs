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
    public class SectionsController : ControllerBase
    {
        private readonly fmsContext _context;
        private readonly SectionService _sectionService;
        private readonly LessonService _lessonService;

        public SectionsController(fmsContext context, SectionService sectionService, LessonService lessonService)
        {
            _context = context;
            _sectionService = sectionService;
            _lessonService = lessonService;
        }

        [HttpGet]
        public IActionResult GetSectionBySectionId(int SectionId) => Ok(_sectionService.GetSectionBySectionId(SectionId));

        [HttpGet]
        public IActionResult GetSectionByCourseId(int CoachId) => Ok(_sectionService.GetSectionByCourseId(CoachId));

        [HttpGet]
        public IActionResult GetSectionByCoachId(int CoachId) => Ok(_sectionService.GetSectionByCoachId(CoachId));

        [HttpDelete]
        public IActionResult DeleteSection(int id) => Ok(_sectionService.DeleteSection(id));

        [HttpPut]
        public IActionResult UpdateSection(Section section) => Ok(_sectionService.UpdateSection(section));
        [HttpPost]
        public IActionResult AddSection(int coachid, int courseid) => Ok(_sectionService.AddSection(coachid, courseid));

        [HttpGet]
        public IActionResult GetLessonBySectionId(int id) => Ok(_lessonService.GetLessonBySectionId(id));

        [HttpGet]
        public IActionResult GetLessonByLessonNo(int no) => Ok(_lessonService.GetLessonByLessonNo(no));

        [HttpGet]
        public IActionResult GetLessonByCoachId(int id) => Ok(_lessonService.GetLessonByCoachId(id));

        [HttpGet]
        public IActionResult GetLessonByStartDate(int startdate) => Ok(_lessonService.GetLessonByStartDate(startdate));

        [HttpPost]
        public IActionResult AddLesson(int sectionid, int coachid, int startdate, int enddate, int state) => Ok(_lessonService.AddLesson(sectionid, coachid, startdate, enddate, state));

        [HttpDelete]
        public IActionResult DeleteLesson(int sectionid, int lessonno) => Ok(_lessonService.DeleteLesson(sectionid, lessonno));

        [HttpPut]
        public IActionResult UpdateLesson(Lesson lesson) => Ok(_lessonService.UpdateLesson(lesson));

        [HttpGet]
        public IActionResult GetCourseProcess(int sectionid) => Ok(_lessonService.GetCourseProcess(sectionid));

        [HttpGet]
        public IActionResult GetCoachLesson(int coachid, int startdate, int num) => Ok(_lessonService.GetCoachLesson(coachid, startdate, num));


    }
}
