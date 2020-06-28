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

    public class CourseService : ICourseService
    {
        private fmsContext context;
        private IMapper mapper;
        public CourseService(fmsContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ResponseModel GetCoursesById(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            Course course = context.Course.AsNoTracking().Single(c => c.CourseId == id);

            if (course != null)
            {
                ResponseModel.SetData(mapper.Map<CourseViewModel>(course));
                ResponseModel.SetSuccess();
            }
            else
                ResponseModel.SetFailed();

            return ResponseModel;
        }
        public ResponseModel GetCoursesByTitle(string title)
        {
            ResponseModel ResponseModel = new ResponseModel();

            List<Course> courses = context.Course.Where(c => c.Title == title).ToList();

            if (courses.Any(c => c != null))
            {
                ResponseModel.SetSuccess();
                ResponseModel.SetData(mapper.Map<List<CourseViewModel>>(courses));
            }
            else
                ResponseModel.SetFailed();

            return ResponseModel;

        }

        public Course Merge(string title, int cost, int classhour)
        {
            Course course = new Course();
            course.Title = title;
            course.Cost = cost;
            course.ClassHour = classhour;
            return course;
        }

        public ResponseModel AddCourse(string title, int cost, int classhour)
        {
            ResponseModel ResponseModel = new ResponseModel();
            Course course = Merge(title, cost, classhour);
            context.Course.Add(course);
            context.SaveChanges();
            if (context.Course.Where(c => c.CourseId == course.CourseId).Any())
            {
                ResponseModel.SetSuccess();
                ResponseModel.SetData(new { course.CourseId });
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;

        }
        public ResponseModel DeleteCourse(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();
            if (id > 0)
            {
                Course course = context.Course.Single(c => c.CourseId == id);
                if (course != null)
                {
                    context.Course.Remove(course);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return ResponseModel;
                }
            }
            ResponseModel.SetFailed("Id not found");
            return ResponseModel;
        }

        public ResponseModel UpdateCourse(Course course)
        {
            ResponseModel ResponseModel = new ResponseModel();

            if (course.CourseId > 0)
            {
                Course temp = context.Course.Where(c => c.CourseId == course.CourseId).FirstOrDefault();
                if (temp != null)
                {
                    temp.CourseId = course.CourseId;
                    temp.Title = course.Title;
                    temp.Cost = course.Cost;
                    temp.ClassHour = course.ClassHour;

                    context.SaveChanges();

                    ResponseModel.SetSuccess();
                    return ResponseModel;
                }
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }


    }
}
