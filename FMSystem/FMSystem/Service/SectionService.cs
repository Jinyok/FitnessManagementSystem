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

namespace FMSystem.Service
{
    public class SectionService
    {
        private static fmsContext context;
        public static Section GetSectionBySectionId(int id)
        {
            Section section = context.Section.Single(s => s.SectionId == id);

            return section;
        }

        public static List<Section> GetSectionByCourseId(int id)
        {
            var sections = context.Section.Where(s => s.CourseId == id).ToList();

            return sections;
        }

        public static List<Section> GetSectionByCoachId(int id)
        {
            var sections = context.Section.Where(s => s.CoachId == id).ToList();

            return sections;
        }

        public static List<Section> GetSectionByStartDate(DateTime time)
        {
            var sections = context.Section.Where(s => s.StartDate == time).ToList();

            return sections;
        }
        public static void AddSection(Section section)
        {
            ResponseModel ResponseModel = new ResponseModel();

            if (section.SectionId > 0)
            {
                if (GetSectionBySectionId(section.SectionId) == null)
                {
                    var sections = context.Section.Where(s => s.StartDate == section.StartDate).ToList();
                    var sections1 = sections.Find(s => s.CoachId == section.CoachId);
                    if (sections1 == null || CoachService.GetCoachesById(sections1.CoachId).State == Coach.CoachState.LeaveOffice)//上课的教练在此时间没有课或已经离职
                    {
                        context.Section.Add(section);
                        context.SaveChanges();
                        ResponseModel.SetSuccess();
                        return;
                    }

                }
            }

            ResponseModel.SetFailed();
            return;
        }

        public static void DeleteSection(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            if (id > 0)
            {
                Section section = GetSectionBySectionId(id);
                if (section != null)
                {
                    context.Section.Remove(section);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return;
                }
            }
            ResponseModel.SetSuccess();
            return;

        }

        public static void UpdateSection(Section section)
        {
            ResponseModel ResponseModel = new ResponseModel();

            if (section.SectionId > 0)
            {
                Section temp = context.Section.Single(s => s.SectionId == section.SectionId);
                if (temp != null)
                {
                    temp.SectionId = section.SectionId;

                    temp.StartDate = section.StartDate;

                    temp.EndDate = section.EndDate;

                    temp.CourseId = section.CourseId;

                    temp.CoachId = section.CoachId;

                    context.SaveChanges();

                    ResponseModel.SetSuccess();
                    return;
                }
            }
            ResponseModel.SetFailed();
            return;
        }
    }
}
