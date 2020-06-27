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
using FMSystem.Extensions;

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
        public IActionResult UpdateSection(SectionViewModel section) => Ok(_sectionService.UpdateSection(section));
        [HttpPost]
        public IActionResult AddSection(SectionCreateViewModel section)
        {
            ResponseModel ResponseModel = new ResponseModel();
            section.SectionId = _context.Section.DefaultIfEmpty().Max(s => s == null ? 0 : s.SectionId) + 1;
            var _section = mapper.Map<SectionCreateViewModel, Section>(section);
            _context.Add(_section);
            try
            {
                _context.SaveChanges();
                ResponseModel.SetData(new { section.SectionId });
                ResponseModel.SetSuccess();
            }
            catch (DbUpdateConcurrencyException)
            {
                ResponseModel.SetFailed();
                if (!_context.Coach.Any(x => x.CoachId == section.CoachId))
                    ResponseModel.Message = $"CoachId doesn't exist: {section.CoachId}";
                else if (!_context.Course.Any(x => x.CourseId == section.CourseId))
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
        public IActionResult GetLessonByStartDate(long startdate) => Ok(_lessonService.GetLessonByStartDate(startdate));

        [HttpPost]
        public IActionResult AddLesson(LessonViewModel lesson) =>
            Ok(_lessonService.AddLesson(lesson));

        [HttpDelete]
        public IActionResult DeleteLesson(int sectionid, int lessonno) => Ok(_lessonService.DeleteLesson(sectionid, lessonno));

        [HttpPut]
        public IActionResult UpdateLesson(LessonViewModel lessonmodel)
        {
            var lesson = mapper.Map<Lesson>(lessonmodel);
            return Ok(_lessonService.UpdateLesson(lesson));
        }

        [HttpGet]
        public IActionResult GetCourseProcess(int sectionid) => Ok(_lessonService.GetCourseProcess(sectionid));

        [HttpGet]
        public IActionResult GetCoachLesson(int coachid, long startdate, int num) => Ok(_lessonService.GetCoachLessons(coachid, startdate, num));

        [HttpGet]
        public IActionResult GetFirstLessonByCoachId(int CoachId)
        {
            var response = new ResponseModel();
            //var course = _context.Course.Single(x => x.Section.Single(s => s.Lesson.Where(l => l.CoachId == CoachId).OrderBy(c => c.StartDate).First()));
            var lessonquery = from l in _context.Lesson
                              where l.CoachId == CoachId
                              select l;
            if (lessonquery.Any())
            {
                var lesson = lessonquery.OrderBy(l => l.StartDate).First();
                //var section = (from s in _context.Section where s.SectionId == lesson.SectionId select s).First();
                var section = _context.Section.AsNoTracking().Include(e => e.Lesson).Include(e => e.Course).Where(e => e.SectionId == lesson.SectionId)
                    .Select(e => new
                    {
                        Title = e.Course.Title,
                        ClassHour = e.Lesson.Count,
                        SectionId = e.SectionId,
                        AttendedHours = e.Lesson.Where(l => l.State == Lesson.LessonState.Finished).Count(),
                        StartDate = lesson.StartDate.Value.ToUnixTimeSeconds()
                    }).Single();
                response.SetSuccess();
                response.SetData(section);
            }
            else
            {
                response.SetFailed("教练无课");
            }
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetSectionMembers(int SectionId)
        {
            var response = new ResponseModel();
            var query = from s in _context.Section.AsNoTracking()
                        join t in _context.Take on s.SectionId equals t.SectionId
                        join m in _context.Member on t.MemberId equals m.MemberId
                        where (s.SectionId == SectionId)
                        select new 
                        {
                            MemberId=m.MemberId,
                            Name=m.Name,
                            PhoneNo=m.PhoneNo.FormatPhoneNo()
                        };
            var Members = query.ToList();
            if (Members.Count == 0)
                response.SetFailed("无人报名课程");
            else
            {
                response.SetSuccess();
                response.SetData(Members);
            }
            return Ok(response);
        }

    }
}
