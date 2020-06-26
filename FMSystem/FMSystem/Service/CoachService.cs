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

        public Coach Package(Coach coaches)
        {
            long no = Convert.ToInt64(coaches.PhoneNo);
            coaches.PhoneNo = string.Format("{0:###-####-####}", no);
            return coaches;
        }

        public ResponseModel GetCoachesById(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            Coach coaches = null;

            coaches = context.Coach.Where(c => c.CoachId == id).FirstOrDefault();

            if (coaches != null)
            {
                coaches = Package(coaches);
                ResponseModel.SetData(coaches);
                ResponseModel.SetSuccess();
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel GetCoachesByName(string name)
        {
            ResponseModel ResponseModel = new ResponseModel();

            List<Coach> coaches = context.Coach.Where(c => c.Name == name).ToList();

            List<Coach> coaches1 = new List<Coach>();
            
            if (coaches.Any(c=>c != null))
            {
                foreach (Coach coach in coaches)
                {
                    coaches1.Add(Package(coach));
                }
                ResponseModel.SetData(coaches1);
                ResponseModel.SetSuccess();
                return ResponseModel;
            }

            ResponseModel.SetFailed();
            return ResponseModel;

        }

        public Coach Merge(string name, string phoneno, string email)
        {
            Coach coach = new Coach();
            coach.Name = name;
            coach.Email = email;
            coach.PhoneNo = phoneno;
            coach.State = Coach.CoachState.InOffice;
            return coach;
        }

        public ResponseModel AddCoach(string name, string phoneno, string email)
        {
            ResponseModel ResponseModel = new ResponseModel();
            Coach coach = Merge(name, phoneno, email);
            context.Coach.Add(coach);
            context.SaveChanges();
            if (context.Coach.Where(c => c.CoachId == coach.CoachId).FirstOrDefault() != null)
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
                Coach coach = context.Coach.Where(c => c.CoachId == id).FirstOrDefault();
                if (coach != null)
                {
                    coach.State = Coach.CoachState.LeaveOffice;
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return ResponseModel;
                }
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel UpdateCoach(Coach coach)
        {
            ResponseModel ResponseModel = new ResponseModel();

            if (coach.CoachId > 0)
            {
                Coach temp = context.Coach.Where(c => c.CoachId == coach.CoachId).FirstOrDefault();
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
