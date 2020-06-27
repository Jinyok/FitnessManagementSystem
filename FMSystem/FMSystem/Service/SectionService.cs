using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMSystem.Controllers;
using FMSystem.Entity;
using FMSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FMSystem.Service;
using FMSystem.Entity.fms;
using FMSystem.Interface;
using AutoMapper;
using FMSystem.ViewModels;

namespace FMSystem.Service
{
    public class SectionService : ISectionService
    {
        private fmsContext context;
        private IMapper mapper;
        public SectionService(fmsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public ResponseModel GetSectionBySectionId(int SectionId)
        {
            ResponseModel ResponseModel = new ResponseModel();

            var query = context.Section
                .AsNoTracking()
                .Include(e => e.Course)
                .Include(e => e.Lesson)
                .Where(e => e.SectionId == SectionId)
                .Select(x => new
                {
                    SectionId = x.SectionId,
                    Title = x.Course.Title,
                    ClassHour = x.Lesson.Count,
                    AttendedHours = x.Lesson.Where(x => x.State == Lesson.LessonState.Finished).Count()
                });
            var section = query.Single();

            if (section == null)
                ResponseModel.SetFailed();
            else
            {
                ResponseModel.SetSuccess();
                ResponseModel.SetData(section);
            }

            return ResponseModel;
        }

        public ResponseModel GetSectionByCourseId(int CourseId)
        {
            ResponseModel ResponseModel = new ResponseModel();

            var query = context.Section
                .AsNoTracking()
                .Include(e => e.Course)
                .Include(e => e.Lesson)
                .Where(e => e.CourseId == CourseId)
                .Select(x => new
                {
                    SectionId = x.SectionId,
                    Title = x.Course.Title,
                    ClassHour = x.Lesson.Count,
                    AttendedHours = x.Lesson.Where(x => x.State == Lesson.LessonState.Finished).Count()
                });

            //var sqlstring=query.toq
            var sections = query.ToList();

            if (sections.Count == 0)
                ResponseModel.SetFailed();
            else
            {
                ResponseModel.SetData(sections);
                ResponseModel.SetSuccess();
            }

            return ResponseModel;
        }

        public ResponseModel GetSectionByCoachId(int CoachId)
        {
            ResponseModel ResponseModel = new ResponseModel();

            var query = context.Section
                .AsNoTracking()
                .Include(e => e.Course)
                .Include(e => e.Lesson)
                .Where(e => e.CoachId == CoachId)
                .Select(x => new
                {
                    SectionId = x.SectionId,
                    Title = x.Course.Title,
                    ClassHour = x.Lesson.Count,
                    AttendedHours = x.Lesson.Where(x => x.State == Lesson.LessonState.Finished).Count()
                });

            //var sqlstring=query.toq
            var sections = query.ToList();

            if (sections.Count == 0)
                ResponseModel.SetFailed();
            else
            {
                ResponseModel.SetData(sections);
                ResponseModel.SetSuccess();
            }

            return ResponseModel;
        }

        //public ResponseModel GetSectionByStartDate(DateTime time)
        //{
        //    ResponseModel ResponseModel = new ResponseModel();

        //    var sections = context.Section.Where(s => s.StartDate == time).ToList();

        //    ResponseModel.SetData(sections);

        //    if (sections == null)
        //        ResponseModel.SetFailed();
        //    else
        //        ResponseModel.SetSuccess();

        //    return ResponseModel;
        //}

        public Section Merge(int coachid, int courseid)
        {
            Section section = new Section();
            section.CoachId = coachid;
            section.CourseId = courseid;
            return section;
        }
        public ResponseModel AddSection(int coachid, int courseid)
        {
            ResponseModel ResponseModel = new ResponseModel();
            if (context.Coach.Any(c => c.CoachId == coachid) && context.Course.Any(c => c.CourseId == courseid))//输入的教练和课程存在
            {
                Section section = Merge(coachid, courseid);
                context.Section.Add(section);
                context.SaveChanges();
                if (GetSectionBySectionId(section.SectionId).Code == 200)
                    ResponseModel.SetSuccess();
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel DeleteSection(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            if (id > 0)
            {
                Section section = context.Section.Single(s => s.SectionId == id);
                if (section != null)
                {
                    context.Section.Remove(section);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return ResponseModel;
                }
            }
            ResponseModel.SetFailed("Id must be greater than 0");
            return ResponseModel;

        }

        public ResponseModel UpdateSection(SectionViewModel sectionmodel)
        {
            ResponseModel ResponseModel = new ResponseModel();
            var section = mapper.Map<Section>(sectionmodel);
            context.Section.Update(section);
            try
            {
                context.SaveChanges();
                ResponseModel.SetSuccess();
            }
            catch (DbUpdateException)
            {
                ResponseModel.SetFailed("Section不存在");
            }

            return ResponseModel;
        }
    }
}
