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
    public class MemberService:IMemberService
    {

        private fmsContext context;

        public MemberService(fmsContext context)
        {
            this.context = context;
        }
        public ResponseModel GetMembersById(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            Member members = context.Member.Single(m => m.MemberId == id);

            ResponseModel.SetData(members);

            if (members == null)
                ResponseModel.SetFailed();
            else
                ResponseModel.SetSuccess();

            return ResponseModel;
        }

        public ResponseModel GetMembersByName(string name)
        {
            ResponseModel ResponseModel = new ResponseModel();

            List<Member> members = context.Member.Where(m => m.Name == name).ToList();

            ResponseModel.SetData(members);

            if (members == null)
                ResponseModel.SetFailed();
            else
                ResponseModel.SetSuccess();

            return ResponseModel;

        }

        public Member Merge(long phoneno, string name)
        {
            Member member = null;
            member.PhoneNo = phoneno;
            member.Name = name;
            return member;
        }

        public ResponseModel AddMember(long phoneno, string name)
        {
            ResponseModel ResponseModel = new ResponseModel();
            Member member = Merge(phoneno, name);
            context.Member.Add(member);
            context.SaveChanges();
            if (GetMembersById(member.MemberId) != null)
            {
                ResponseModel.SetSuccess();
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
            ResponseModel.SetSuccess();
            return ResponseModel;
        }

        public ResponseModel UpdateMember(Member member)
        {
            ResponseModel ResponseModel = new ResponseModel();
            if (member.MemberId > 0)
            {
                Member temp = context.Member.Single(m => m.MemberId == member.MemberId);
                if (temp != null)
                {
                    temp.MemberId = member.MemberId;

                    temp.Name = member.Name;

                    temp.PhoneNo = member.PhoneNo;

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
