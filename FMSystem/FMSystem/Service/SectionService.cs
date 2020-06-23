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
    public class SectionService:ISectionService
    {
        private fmsContext context;
        public SectionService(fmsContext context)
        {
            this.context = context;
        }
        public ResponseModel GetSectionBySectionId(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            Section section = context.Section.Single(s => s.SectionId == id);

            ResponseModel.SetData(section);

            if (section == null)
                ResponseModel.SetFailed();
            else
                ResponseModel.SetSuccess();

            return ResponseModel;
        }

        public ResponseModel GetSectionByCourseId(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            var sections = context.Section.Where(s => s.CourseId == id).ToList();

            ResponseModel.SetData(sections);

            if (sections == null)
                ResponseModel.SetFailed();
            else
                ResponseModel.SetSuccess();

            return ResponseModel;
        }

        public ResponseModel GetSectionByCoachId(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            var sections = context.Section.Where(s => s.CoachId == id).ToList();

            ResponseModel.SetData(sections);

            if (sections == null)
                ResponseModel.SetFailed();
            else
                ResponseModel.SetSuccess();

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

        public Section Merge(int coachid, int courseid, DateTime startdate, DateTime enddate)
        {
            Section section = null;
            section.CoachId = coachid;
            section.CourseId = courseid;
            //section.StartDate = startdate;
            //section.EndDate = enddate;
            return section;
        }
        //public ResponseModel AddSection(int coachid, int courseid, DateTime startdate, DateTime enddate)
        //{
        //    ResponseModel ResponseModel = new ResponseModel();
        //    Section section = Merge(coachid, courseid, startdate, enddate);
        //    var sections = context.Section.Where(s => s.StartDate == section.StartDate).ToList();
        //    var sections1 = sections.Find(s => s.CoachId == section.CoachId);
        //    if (sections1 == null || context.Coach.Single(c => c.CoachId == section.CoachId).State == Coach.CoachState.LeaveOffice)//上课的教练在此时间没有课或已经离职
        //    {
        //                context.Section.Add(section);
        //                context.SaveChanges();
        //        if(GetSectionBySectionId(section.SectionId) != null)
        //                ResponseModel.SetSuccess();
        //                return ResponseModel;
        //     }

        //    ResponseModel.SetFailed();
        //    return ResponseModel;
        //}

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
            ResponseModel.SetSuccess();
            return ResponseModel;

        }

        public ResponseModel UpdateSection(Section section)
        {
            ResponseModel ResponseModel = new ResponseModel();

            if (section.SectionId > 0)
            {
                Section temp = context.Section.Single(s => s.SectionId == section.SectionId);
                if (temp != null)
                {
                    temp.SectionId = section.SectionId;

                    //temp.StartDate = section.StartDate;

                    //temp.EndDate = section.EndDate;

                    temp.CourseId = section.CourseId;

                    temp.CoachId = section.CoachId;

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
