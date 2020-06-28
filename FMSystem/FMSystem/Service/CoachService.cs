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
using FMSystem.Extensions;

namespace FMSystem.Service
{

    public class CoachService : ICoachService
    {
        private fmsContext context;
        private IMapper mapper;
        public CoachService(fmsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ResponseModel GetCoachesById(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            Coach coach = context.Coach.Single(s => s.CoachId == id);

            if (coach != null)
            {
                var coacheModels = mapper.Map<CoachViewModel>(coach);
                coacheModels.PhoneNo = coacheModels.PhoneNo.FormatPhoneNo();
                ResponseModel.SetData(coacheModels);
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


            if (coaches.Any(c => c != null))
            {
                var coachesModel = mapper.Map<List<CoachViewModel>>(coaches);
                foreach (var x in coachesModel)
                    x.PhoneNo = x.PhoneNo.FormatPhoneNo();
                
                ResponseModel.SetData(coachesModel);
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
                ResponseModel.SetData(new { coach.CoachId });
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
            ResponseModel.SetFailed("Id must be greater than 0");
            return ResponseModel;
        }

        public ResponseModel UpdateCoach(CoachViewModel coachmodel)
        {
            ResponseModel ResponseModel = new ResponseModel();
            var coach = mapper.Map<Coach>(coachmodel);
            if (coach.CoachId > 0)
            {
                context.Coach.Update(coach);
                context.SaveChanges();
                ResponseModel.SetSuccess();
                return ResponseModel;

            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }
    }
}
