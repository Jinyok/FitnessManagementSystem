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

    public class CoachService
    {
        private static fmsContext context;


        public static ResponseModel GetCoachesById(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            Coach coaches = context.Coach.Single(c => c.CoachId == id);

            ResponseModel.SetData(coaches);

            if (coaches == null)
                ResponseModel.SetFailed();
            else
                ResponseModel.SetSuccess();

            return ResponseModel;
        }

        public static ResponseModel GetCoachesByName(string name)
        {
            ResponseModel ResponseModel = new ResponseModel();

            List<Coach> coaches = context.Coach.Where(c => c.Name == name).ToList();

            ResponseModel.SetData(coaches);

            if (coaches == null)
                ResponseModel.SetFailed();
            else
                ResponseModel.SetSuccess();

            return ResponseModel;

        }

        public static ResponseModel AddCoach(Coach coach)
        {
            ResponseModel ResponseModel = new ResponseModel();
            if (coach.CoachId > 0)//合法性
            {
                if (GetCoachesById(coach.CoachId) == null)//主键唯一性
                {
                    context.Coach.Add(coach);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return ResponseModel;
                }
            }
            ResponseModel.SetFailed();
            return ResponseModel;

        }

        public static ResponseModel DeleteCoach(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();
            if (id > 0)
            {
                Coach coach = context.Coach.Single(c => c.CoachId == id);
                if (coach != null)
                {
                    coach.State = Coach.CoachState.LeaveOffice;
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return ResponseModel;
                }
            }
            ResponseModel.SetSuccess();
            return ResponseModel;
        }

        public static ResponseModel UpdateCoach(Coach coach)
        {
            ResponseModel ResponseModel = new ResponseModel();

            if (coach.CoachId > 0)
            {
                Coach temp = context.Coach.Single(c => c.CoachId == coach.CoachId);
                if (temp != null)
                {
                    temp.CoachId = coach.CoachId;

                    temp.Name = coach.Name;

                    temp.Email = coach.Email;

                    temp.PhoneNo = coach.PhoneNo;

                    temp.State = coach.State;

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
