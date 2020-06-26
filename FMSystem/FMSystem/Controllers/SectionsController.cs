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
using FMSystem.Models;
using AutoMapper;

namespace FMSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly fmsContext _context;
        private readonly SectionService _sectionService;
        private readonly LessonService _lessonService;
        private readonly IMapper mapper;

        public SectionsController(fmsContext context, SectionService sectionService, LessonService lessonService, IMapper mapper)
        {
            _context = context;
            _sectionService = sectionService;
            _lessonService = lessonService;
            this.mapper = mapper;
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
        public IActionResult AddSection(SectionViewModel section)
        {
            ResponseModel ResponseModel = new ResponseModel();
            section.SectionId = _context.Section.Count() + 1;
            var _section = mapper.Map<SectionViewModel, Section>(section);
            _context.Add(_section);
            try
            {
                _context.SaveChanges();
                ResponseModel.SetData(new { section.SectionId });
                ResponseModel.SetSuccess();
            }
            catch(DbUpdateConcurrencyException)
            {
                ResponseModel.SetFailed();
                if (!_context.Coach.Any(x => x.CoachId == section.CoachId))
                    ResponseModel.Message = $"CoachId doesn't exist: {section.CoachId}";
                else if(!_context.Course.Any(x=>x.CourseId==section.CourseId))
                    ResponseModel.Message = $"CourseId doesn't exist: {section.CourseId}";

            }

            return Ok(ResponseModel);
        }

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
