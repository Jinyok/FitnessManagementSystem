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
    public class InstructsService : IInstructsService
    {
        private fmsContext context;
        public InstructsService(fmsContext context)
        {
            this.context = context;
        }
        public ResponseModel GetInstructsByMemberId(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            var instructs = context.Instructs.Where(i => i.MemberId == id).ToList();

            ResponseModel.SetData(instructs);

            if (instructs.Any(i=>i != null))
                ResponseModel.SetSuccess();
            else
                ResponseModel.SetFailed();

            return ResponseModel;
        }


        public ResponseModel GetInstructsByCoachId(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            var instructs = context.Instructs.Where(i => i.CoachId == id).ToList();

            ResponseModel.SetData(instructs);

            if (instructs.Any(i => i != null))
                ResponseModel.SetSuccess();
            else
                ResponseModel.SetFailed();

            return ResponseModel;
        }

        public ResponseModel AddInstructs(Instructs instructs)
        {
            ResponseModel ResponseModel = new ResponseModel();
            if (instructs.MemberId > 0 && instructs.CoachId > 0)
            {
                var instruct = context.Instructs.Where(i => i.MemberId == instructs.MemberId).ToList();
                var instruct1 = context.Instructs.Where(i => i.CoachId == instructs.CoachId).ToList();
                if (instruct.Any(i => i != null) && instruct1.Any(i => i != null))
                {
                    context.Instructs.Add(instructs);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return ResponseModel;
                }
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel DeleteInstructs(int memberid, int coachid)
        {
            ResponseModel ResponseModel = new ResponseModel();
            if (memberid > 0 && coachid > 0)
            {
                var instructs = context.Instructs.Where(i => i.MemberId == memberid).ToList();
                var instruct1 = instructs.Find(i => i.CoachId == coachid);
                if (instruct1 != null)
                {
                    context.Instructs.Remove(instruct1);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return ResponseModel;
                }
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel UpdateInstructs(Instructs instructs)
        {
            ResponseModel ResponseModel = new ResponseModel();
            if (instructs.MemberId > 0 && instructs.CoachId > 0)
            {

                var instruct = context.Instructs.Where(i => i.MemberId == instructs.MemberId).ToList();
                var instruct1 = instruct.Find(i => i.CoachId == instructs.CoachId);
                if (instruct1 != null)
                {
                    instruct1.MemberId = instructs.MemberId;
                    instruct1.CoachId = instructs.CoachId;
                    instruct1.TotalHours = instructs.TotalHours;
                    instruct1.AttendedHours = instructs.AttendedHours;

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
