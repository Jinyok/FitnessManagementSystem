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
using Microsoft.Extensions.Logging;


namespace FMSystem.Service
{

    public class CoachService
    {
        private static fmsContext context;


        public static Coach GetCoachesById(int id)
        {
            Coach coaches = context.Coach.Single(c => c.CoachId == id);

            return coaches;
        }

        public static List<Coach> GetCoachesByName(string name)
        {
            List<Coach> coaches = context.Coach.Where(c => c.Name == name).ToList();

            return coaches;

        }

        public static void AddCoach(Coach coach)
        {
         ResponseModel ResponseModel = new ResponseModel();
            if (coach.CoachId > 0)//合法性
            {
                if (GetCoachesById(coach.CoachId) == null)//主键唯一性
                {
                    context.Coach.Add(coach);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return;
                }
            }
            ResponseModel.SetFailed();
            
        }

        public static void DeleteCoach(int id)
        {
         ResponseModel ResponseModel = new ResponseModel();
            Coach coach = GetCoachesById(id);

            if (coach == null)
            {
                ResponseModel.SetFailed();
                return;
            }

            context.Coach.Remove(coach);
            
            context.SaveChanges();

            ResponseModel.SetSuccess();
        }

        public static void UpdateCoach(Coach coach)
        {
         ResponseModel ResponseModel = new ResponseModel();
            if (coach.CoachId > 0)
            {
                Coach temp = context.Coach.Find(coach.CoachId);
                if (temp == null)
                {
                    ResponseModel.SetFailed();
                    return;
                }

                temp.CoachId = coach.CoachId;

                temp.Name = coach.Name;

                temp.Email = coach.Email;

                temp.PhoneNo = coach.PhoneNo;

                context.SaveChanges();

                ResponseModel.SetSuccess();
                return;
            }
            ResponseModel.SetFailed();
            return;
        }
    }
}
