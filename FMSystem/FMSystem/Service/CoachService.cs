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

    public class CoachService:ICoachService
    {
        private fmsContext context;
        public CoachService(fmsContext context)
        {
            this.context = context;
        }

        public ResponseModel GetCoachesById(int id)
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

        public ResponseModel GetCoachesByName(string name)
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

        public Coach Merge(string name, long phoneno, string email)
        {
            Coach coach = null;
            coach.Name = name;
            coach.Email = email;
            coach.State = Coach.CoachState.InOffice;
            return coach;
        }

        public ResponseModel AddCoach(string name, long phoneno, string email)
        {
            ResponseModel ResponseModel = new ResponseModel();
            Coach coach = Merge(name, phoneno, email);
            context.Coach.Add(coach);
            context.SaveChanges();
            if (GetCoachesById(coach.CoachId) != null)
            {
                ResponseModel.SetSuccess();
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;

        }

        public ResponseModel DeleteCoach(int id)
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

        public ResponseModel UpdateCoach(Coach coach)
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
