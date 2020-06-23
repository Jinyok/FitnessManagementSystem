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

namespace FMSystem.Service
{
    public class LessonService
    {
        private fmsContext context;

        public LessonService(fmsContext context)
        {
            this.context = context;
        }

        public ResponseModel GetLessonBySectionId(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();
            List<Lesson> lesson = context.Lesson.Where(l => l.SectionId == id).ToList();
            if (lesson != null)
            {
                ResponseModel.SetSuccess();
                ResponseModel.SetData(lesson);
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel GetLessonByLessonNo(int no)
        {
            ResponseModel ResponseModel = new ResponseModel();
            List<Lesson> lesson = context.Lesson.Where(l => l.LessonNo == no).ToList();
            if (lesson != null)
            {
                ResponseModel.SetSuccess();
                ResponseModel.SetData(lesson);
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel GetLessonByCoachId(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();
            List<Lesson> lesson = context.Lesson.Where(l => l.CoachId == id).ToList();
            if (lesson != null)
            {
                ResponseModel.SetSuccess();
                ResponseModel.SetData(lesson);
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel GetLessonByStartDate(DateTimeOffset startdate)
        {
            ResponseModel ResponseModel = new ResponseModel();
            List<Lesson> lesson = context.Lesson.Where(l => l.StartDate == startdate).ToList();
            if (lesson != null)
            {
                ResponseModel.SetSuccess();
                ResponseModel.SetData(lesson);
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }
        public Lesson Merge(int sectionid, int coachid, DateTimeOffset startdate, DateTimeOffset enddate)
        {
            Lesson lesson = null;
            lesson.SectionId = sectionid;
            lesson.CoachId = coachid;
            lesson.LessonNo = 1;//默认为第一节课
            lesson.StartDate = startdate;
            lesson.EndDate = enddate;
            return lesson;
        }

        public ResponseModel AddLesson(int sectionid, int coachid, DateTimeOffset startdate, DateTimeOffset enddate)
        {
            ResponseModel ResponseModel = new ResponseModel();
            Lesson lesson = Merge(sectionid, coachid, startdate, enddate);
            List<Lesson> lesson1 = context.Lesson.Where(l => l.SectionId == sectionid).ToList();
            if ( lesson1 != null)
            {
                lesson.LessonNo = lesson1.Count() + 1;//计算已经上了几节课并在此基础上+1
            }
            context.Lesson.Add(lesson);
            context.SaveChanges();
            if(lesson1.Any(l=>l.LessonNo==lesson.LessonNo))
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
            if(lesson != null)
            {
                var lesson1 = lesson.Single(l => l.LessonNo == lessonno);
                if(lesson1 != null)
                {
                    for(int i = lesson.Count - 1; i > lesson1.LessonNo; i--)
                    {
                        lesson[i].LessonNo--;//将对应的课时编号向前一位
                    }
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
            if(lesson1 != null)
            {
                var lesson2 = lesson1.Single(l => l.LessonNo == lesson.LessonNo);
                if (lesson2 != null)
                {
                    lesson2.CoachId = lesson.CoachId;
                    lesson2.StartDate = lesson.StartDate;
                    lesson2.EndDate = lesson.EndDate;
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
            if(lesson != null)
            {
                int totalhours = 0;
                for(int i = 0; i < lesson.Count; i++)
                {
                    totalhours +=  lesson[i].EndDate.Value.Hour - lesson[i].StartDate.Value.Hour;
                }
                ResponseModel.SetData(totalhours);
                ResponseModel.SetSuccess();
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

    }
}
