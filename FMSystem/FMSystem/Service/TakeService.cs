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

namespace FMSystem.Service
{
    public class TakeService
    {
        private static fmsContext context;

        public static List<Takes> GetTakesByMemberId(int id)
        {
            var takes = context.Take.Where(t => t.MemberId == id).ToList();

            return takes;
        }

        public static List<Takes> GetTakesBySectionId(int id)
        {
            var takes = context.Take.Where(t => t.SectionId == id).ToList();

            return takes;
        }

        public static void AddTakes(Takes takes)
        {
            ResponseModel ResponseModel = new ResponseModel();
            if(takes.MemberId > 0 && takes.SectionId > 0)
            {
                var take = context.Take.Where(t => t.MemberId == takes.MemberId).ToList();
                var take1 = take.Find(t => t.SectionId == takes.SectionId);
                if (take1 == null)
                {
                    context.Take.Add(takes);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return;
                }
            }
            ResponseModel.SetFailed();
            return;
        }

        public static void DeleteTakes(int memberid, int sectionid)
        {
            ResponseModel ResponseModel = new ResponseModel();
            if (memberid > 0 && sectionid > 0)
            {
                var takes = context.Take.Where(t => t.MemberId == memberid).ToList();
                var takes1 = takes.Find(t => t.SectionId == sectionid);
                if (takes1 != null)
                {
                    context.Take.Remove(takes1);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return;
                }
            }
            ResponseModel.SetFailed();
            return;
        }

        public static void UpdateTakes(Takes takes)
        {
            ResponseModel ResponseModel = new ResponseModel();
            if(takes.MemberId > 0 && takes.SectionId > 0)
            {
                var take = context.Take.Where(t => t.MemberId == takes.MemberId).ToList();
                var take1 = take.Find(t => t.SectionId == takes.SectionId);
                if(take1 != null)
                {
                    take1.MemberId = takes.MemberId;
                    take1.SectionId = takes.SectionId;
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
