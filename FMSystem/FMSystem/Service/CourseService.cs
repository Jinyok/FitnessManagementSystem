﻿using System;
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

    public class CourseService : ICourseService
    {
        private fmsContext context;
        public CourseService(fmsContext context)
        {
            this.context = context;
        }

        public ResponseModel GetCoursesById(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            Course courses = context.Course.Where(c => c.CourseId == id).FirstOrDefault();

            ResponseModel.SetData(courses);

            if (courses == null)
                ResponseModel.SetFailed();
            else
                ResponseModel.SetSuccess();

            return ResponseModel;
        }
        public ResponseModel GetCoursesByTitle(string title)
        {
            ResponseModel ResponseModel = new ResponseModel();

            List<Course> courses = context.Course.Where(c => c.Title == title).ToList();

            ResponseModel.SetData(courses);

            if (courses.Any(c=>c !=null))
                ResponseModel.SetSuccess();
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
            if (context.Course.Where(c => c.CourseId == course.CourseId).FirstOrDefault() != null)
            {
                ResponseModel.SetSuccess();
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
            ResponseModel.SetSuccess();
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
