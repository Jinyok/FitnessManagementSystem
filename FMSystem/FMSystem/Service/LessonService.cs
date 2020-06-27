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
using FMSystem.Extensions;

namespace FMSystem.Service
{
    public class LessonService
    {
        private fmsContext context;
        private IMapper mapper;
        public LessonService(fmsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ResponseModel GetLessonBySectionId(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();
            List<Lesson> lesson = context.Lesson.Where(l => l.SectionId == id).ToList();
            if (lesson.Any(l => l != null))
            {
                var lessonModels = mapper.Map<List<LessonViewModel>>(lesson);
                ResponseModel.SetSuccess();
                ResponseModel.SetData(lessonModels);
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel GetLessonByLessonNo(int no)
        {
            ResponseModel ResponseModel = new ResponseModel();
            List<Lesson> lesson = context.Lesson.Where(l => l.LessonNo == no).ToList();
            if (lesson.Any(l => l != null))
            {
                var lessonModels = mapper.Map<List<LessonViewModel>>(lesson);
                ResponseModel.SetSuccess();
                ResponseModel.SetData(lessonModels);
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel GetLessonByCoachId(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();
            List<Lesson> lesson = context.Lesson.Where(l => l.CoachId == id).ToList();
            if (lesson.Any(l => l != null))
            {
                var lessonModels = mapper.Map<List<LessonViewModel>>(lesson);
                ResponseModel.SetSuccess();
                ResponseModel.SetData(lessonModels);
                return ResponseModel;
            }

            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel GetLessonByStartDate(long startdate)
        {
            ResponseModel ResponseModel = new ResponseModel();
            DateTimeOffset date = DateTimeOffset.FromUnixTimeSeconds(startdate);
            List<Lesson> lesson = context.Lesson.Where(l => l.StartDate == date).ToList();
            if (lesson.Any(l => l != null))
            {
                var lessonModels = mapper.Map<List<LessonViewModel>>(lesson);
                ResponseModel.SetSuccess();
                ResponseModel.SetData(lessonModels);
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel GetCoachLesson(int coachid, long startdate, int num)
        {
            ResponseModel ResponseModel = new ResponseModel();
            //int i = 0;
            DateTimeOffset date = DateTimeOffset.FromUnixTimeSeconds(startdate);
            //var lessons1 = context.Lesson.Where(l => l.StartDate.Value > date).ToList();
            //List<Lesson> lessons = new List<Lesson>();
            //foreach (Lesson lesson in lessons1.OrderBy(l => l.StartDate.Value))
            //{
            //    if (i < num)
            //    {
            //        lessons.Add(lesson);
            //        i++;
            //    }
            //}
            //if(lessons.Any(l => l != null))
            //{
            //    ResponseModel.SetSuccess();
            //    ResponseModel.SetData(lessons);
            //    return ResponseModel;
            //}
            //ResponseModel.SetFailed();
            var lessons = (from l in context.Lesson
                           join s in context.Section on l.SectionId equals s.SectionId
                           join c in context.Course on s.CourseId equals c.CourseId
                           where l.StartDate.Value >= date && l.CoachId == coachid
                           select new { lesson = l, c.Title }).ToList();

            if (lessons.Count == 0)
                ResponseModel.SetFailed("无课");
            else
            {
                var list = new List<object>();
                var res = lessons.GroupBy(group => group.lesson.StartDate.Value.ToUnixTimeSeconds() / (24 * 60 * 60)).Select(x => x.Select(v => v).ToList()).ToList();
                foreach (var x in res)
                {
                    if (num <= 0)
                        break;
                    var da = x[0].lesson.StartDate.Value;
                    var list2 = new List<object>();
                    foreach (var x2 in x)
                    {
                        if (num-- <= 0)
                            break;

                        list2.Add(new
                        {
                            LessonId = x2.lesson.LessonNo,
                            SectionId = x2.lesson.SectionId,
                            Title = x2.Title,
                            StartDate = x2.lesson.StartDate.Value.ToUnixTimeSeconds(),
                            EndDate = x2.lesson.EndDate.Value.ToUnixTimeSeconds(),
                        });

                    }

                    list.Add(new
                    {
                        Week = da.DayOfWeek.ToStringCh(),
                        Date = $"{da.Month}月{da.Day}日",
                        Lessons = list2
                    });

                }
                ResponseModel.SetData(list);
                ResponseModel.SetSuccess();
            }
            return ResponseModel;
        }
        public Lesson Merge(int sectionid, int coachid, long startdate, long enddate, int state)
        {
            Lesson lesson = new Lesson();
            DateTimeOffset sdate = DateTimeOffset.FromUnixTimeSeconds(startdate);
            DateTimeOffset edate = DateTimeOffset.FromUnixTimeSeconds(enddate);
            lesson.SectionId = sectionid;
            lesson.CoachId = coachid;
            lesson.LessonNo = 1;//默认为第一节课
            lesson.StartDate = sdate;
            lesson.EndDate = edate;
            if (state == 1)
                lesson.State = Lesson.LessonState.Finished;
            else
                lesson.State = Lesson.LessonState.NotFinished;
            return lesson;
        }

        public ResponseModel AddLesson(LessonViewModel lessonviewmodel)
        {
            ResponseModel ResponseModel = new ResponseModel();
            //Lesson lesson = Merge(sectionid, coachid, startdate, enddate, state);
            Lesson lesson = mapper.Map<Lesson>(lessonviewmodel);
            lesson.LessonNo = context.Lesson.Where(e => e.SectionId == lesson.SectionId).Count() + 1;
            //List<Lesson> lesson1 = context.Lesson.Where(l => l.SectionId == lesson.SectionId).ToList();
            //if (lesson1 != null)
            //{
            //    lesson.LessonNo = lesson1.Count() + 1;//计算已经上了几节课并在此基础上+1
            //}

            //context.Lesson.Add(lesson);
            //context.SaveChanges();
            //var lesson1 = context.Lesson.Where(l => l.SectionId == sectionid).ToList();
            //if (lesson1.Any(l => l.LessonNo == lesson.LessonNo))
            //{

            //    ResponseModel.SetSuccess();
            //    return ResponseModel;
            //}
            //ResponseModel.SetFailed();
            context.Add(lesson);
            try
            {
                context.SaveChanges();
                ResponseModel.SetSuccess();
            }
            catch(DbUpdateException)
            {
                ResponseModel.SetFailed();
                if (!context.Section.Any(e => e.SectionId == lesson.SectionId))
                    ResponseModel.SetFailed("SectionId不存在");
                else if (!context.Coach.Any(e => e.CoachId == lesson.CoachId))
                    ResponseModel.SetFailed("CoachId不存在");
            }

            return ResponseModel;
        }

        public ResponseModel DeleteLesson(int sectionid, int lessonno)
        {
            ResponseModel ResponseModel = new ResponseModel();
            var lesson = context.Lesson.Where(l => l.SectionId == sectionid).ToList();
            if (lesson.Any(l => l != null))
            {
                var lesson1 = lesson.Where(l => l.LessonNo == lessonno).FirstOrDefault();
                if (lesson1 != null)
                {
                    int j = lesson1.LessonNo;
                    if (lesson.Count > 2)
                    {
                        for (int i = j; i <= lesson.Count - 1; i++)
                        {
                            lesson[i - 1].StartDate = lesson[i].StartDate;
                            lesson[i - 1].EndDate = lesson[i].EndDate;
                            lesson[i - 1].CoachId = lesson[i].CoachId;
                            lesson[i - 1].State = lesson[i].State;
                        }
                    }
                    else
                    {
                        lesson[0].StartDate = lesson[1].StartDate;
                        lesson[0].EndDate = lesson[1].EndDate;
                        lesson[0].CoachId = lesson[1].CoachId;
                        lesson[0].State = lesson[1].State;
                    }
                    int m = lesson.Max(l => l.LessonNo);
                    lesson1 = context.Lesson.Where(l => l.LessonNo == m).FirstOrDefault();
                    context.Lesson.Remove(lesson1);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return ResponseModel;
                }
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel UpdateLesson(Lesson lesson)
        {
            ResponseModel ResponseModel = new ResponseModel();
            //var lesson1 = context.Lesson.Where(l => l.SectionId == lesson.SectionId).ToList();
            //if (lesson1.Any(l => l != null))
            //{
            //    var lesson2 = lesson1.Where(l => l.LessonNo == lesson.LessonNo).FirstOrDefault();
            //    if (lesson2 != null)
            //    {
            //        lesson2.CoachId = lesson.CoachId;
            //        lesson2.StartDate = lesson.StartDate;
            //        lesson2.EndDate = lesson.EndDate;
            //        lesson2.State = lesson.State;
            //        context.SaveChanges();
            //        ResponseModel.SetSuccess();
            //        return ResponseModel;
            //    }
            //}
            context.Lesson.Update(lesson);
            try
            {
                context.SaveChanges();
                ResponseModel.SetSuccess();
            }
            catch (DbUpdateException)
            {
                ResponseModel.SetFailed("Lesson不存在");
            }
            return ResponseModel;
        }
        public ResponseModel GetCourseProcess(int sectionid)
        {
            ResponseModel ResponseModel = new ResponseModel();
            var lesson = context.Lesson.Where(l => l.SectionId == sectionid).ToList();
            if (lesson.Any(l => l != null))
            {
                double totalhours = 0;
                for (int i = 0; i < lesson.Count; i++)
                {
                    totalhours += (double)(lesson[i].EndDate.Value.Hour - lesson[i].StartDate.Value.Hour) + (double)(lesson[i].EndDate.Value.Minute - lesson[i].StartDate.Value.Minute) / 60;
                }
                ResponseModel.SetData(totalhours.ToString("0.00"));
                ResponseModel.SetSuccess();
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

    }
}
