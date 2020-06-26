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
            int i = 0;
            DateTimeOffset date = DateTimeOffset.FromUnixTimeSeconds(startdate);
            var lessons1 = context.Lesson.Where(l => l.StartDate.Value > date).ToList();
            List<Lesson> lessons = new List<Lesson>();
            foreach (Lesson lesson in lessons1.OrderBy(l => l.StartDate.Value))
            {
                if (i < num)
                {
                    lessons.Add(lesson);
                    i++;
                }
            }
            if (lessons.Any(l => l != null))
            {
                var lessonModels = mapper.Map<List<LessonViewModel>>(lessons);
                ResponseModel.SetSuccess();
                ResponseModel.SetData(lessonModels);
                return ResponseModel;
            }
            ResponseModel.SetFailed();
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

        public ResponseModel AddLesson(int sectionid, int coachid, long startdate, long enddate, int state)
        {
            ResponseModel ResponseModel = new ResponseModel();
            Lesson lesson = Merge(sectionid, coachid, startdate, enddate, state);
            List<Lesson> lesson1 = context.Lesson.Where(l => l.SectionId == sectionid).ToList();
            if (lesson1 != null)
            {
                lesson.LessonNo = lesson1.Count() + 1;//计算已经上了几节课并在此基础上+1
            }

            context.Lesson.Add(lesson);
            context.SaveChanges();
            lesson1 = context.Lesson.Where(l => l.SectionId == sectionid).ToList();
            if (lesson1.Any(l => l.LessonNo == lesson.LessonNo))
            {

                ResponseModel.SetSuccess();
                return ResponseModel;
            }
            ResponseModel.SetFailed();
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
            var lesson1 = context.Lesson.Where(l => l.SectionId == lesson.SectionId).ToList();
            if (lesson1.Any(l => l != null))
            {
                var lesson2 = lesson1.Where(l => l.LessonNo == lesson.LessonNo).FirstOrDefault();
                if (lesson2 != null)
                {
                    lesson2.CoachId = lesson.CoachId;
                    lesson2.StartDate = lesson.StartDate;
                    lesson2.EndDate = lesson.EndDate;
                    lesson2.State = lesson.State;
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return ResponseModel;
                }
            }
            ResponseModel.SetFailed();
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
