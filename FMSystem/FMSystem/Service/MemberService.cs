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
using FMSystem.ViewModels;
using AutoMapper;
using FMSystem.Extensions;

namespace FMSystem.Service
{
    public class MemberService : IMemberService
    {

        private fmsContext context;
        private IMapper mapper;

        public MemberService(fmsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public ResponseModel GetMembersById(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            Member member = context.Member.Single(m => m.MemberId == id);

            if (member == null)
                ResponseModel.SetFailed();
            else
            {
                ResponseModel.SetSuccess();
                var res = mapper.Map<MemberViewModel>(member);
                res.PhoneNo = res.PhoneNo.FormatPhoneNo();
                ResponseModel.SetData(res);
            }

            return ResponseModel;
        }

        public ResponseModel GetMembersByName(string name)
        {
            ResponseModel ResponseModel = new ResponseModel();

            List<Member> members = context.Member.Where(m => m.Name == name).ToList();


            if (members.Count == 0)
                ResponseModel.SetFailed();
            else
            {
                var res = mapper.Map<List<MemberViewModel>>(members);
                foreach (var x in res)
                    x.PhoneNo = x.PhoneNo.FormatPhoneNo();
                ResponseModel.SetSuccess();
                ResponseModel.SetData(res);
            }

            return ResponseModel;

        }

        public Member Merge(string phoneno, string name)
        {
            Member member = new Member();
            member.PhoneNo = phoneno;
            member.Name = name;
            return member;
        }

        public ResponseModel AddMember(string phoneno, string name)
        {
            ResponseModel ResponseModel = new ResponseModel();
            Member member = Merge(phoneno, name);
            context.Member.Add(member);
            context.SaveChanges();
            if (context.Member.Where(m => m.MemberId == member.MemberId).Any())
            {
                ResponseModel.SetSuccess();
                ResponseModel.SetData(new { member.MemberId });
                return ResponseModel;
            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

        public ResponseModel DeleteMember(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            if (id > 0)
            {
                Member member = context.Member.Single(m => m.MemberId == id);
                if (member != null)
                {
                    context.Member.Remove(member);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return ResponseModel;
                }
            }
            ResponseModel.SetFailed("Id must be greater than 0");
            return ResponseModel;
        }

        public ResponseModel UpdateMember(MemberViewModel membermodel)
        {
            ResponseModel ResponseModel = new ResponseModel();
            var member = mapper.Map<Member>(membermodel);
            if (member.MemberId > 0)
            {
                context.Member.Update(member);
                context.SaveChanges();
                ResponseModel.SetSuccess();
                return ResponseModel;

            }
            ResponseModel.SetFailed();
            return ResponseModel;
        }

    }
}
