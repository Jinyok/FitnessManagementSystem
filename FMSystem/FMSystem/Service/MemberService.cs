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
    public class MemberService
    {

        private static fmsContext context;

        public static Member GetMembersById(int id)
        {
            Member members = context.Member.Single(m => m.MemberId == id);

            return members;
        }

        public static List<Member> GetMembersByName(string name)
        {
            List<Member> members = context.Member.Where(m => m.Name == name).ToList();

            return members;

        }

        public static void AddMember(Member member)
        {
            ResponseModel ResponseModel = new ResponseModel();
            if (member.MemberId > 0)//合法性
            {
                if (GetMembersById(member.MemberId) == null)//主键唯一性
                {
                    context.Member.Add(member);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return;
                }
            }
            ResponseModel.SetFailed();

        }

        public static void DeleteMember(int id)
        {
            ResponseModel ResponseModel = new ResponseModel();

            if (id > 0)
            {
                Member member = GetMembersById(id);
                if (member != null)
                {
                    context.Member.Remove(member);
                    context.SaveChanges();
                    ResponseModel.SetSuccess();
                    return;
                }
            }
            ResponseModel.SetSuccess();
            return;
        }

        public static void UpdateMember(Member member)
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
                    return;
                }
            }
            ResponseModel.SetFailed();
            return;
        }

    }
}
