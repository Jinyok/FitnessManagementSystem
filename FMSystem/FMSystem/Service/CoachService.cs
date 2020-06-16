using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMSystem.Entity;
using FMSystem.Models;
using Microsoft.EntityFrameworkCore;


namespace FMSystem.Service
{
    public class CoachService
    {
        readonly fmsContext context;
        public Coach GetCoachesById(int id)
        {
            Coach coaches = context.Coach.Single(c => c.CoachId == id);

            return coaches;
        }

        public List<Coach> GetCoachesByName(string name)
        {
            List<Coach> coaches = context.Coach.Where(c => c.Name == name).ToList();

            return coaches;
        }

        public void AddCoach(Coach coach)
        {
            context.Coach.Add(coach);
            context.SaveChanges();
        }

        public void DeleteCoach(int id)
        {
            context.Coach.Remove(GetCoachesById(id));
            context.SaveChanges();
        }

        public void UpdateCoach(Coach coach)
        {
            Coach temp = context.Coach.Find(coach.CoachId);
            
            temp.CoachId = coach.CoachId;

            temp.Name = coach.Name;

            temp.Email = coach.Email;

            temp.PhoneNo = coach.PhoneNo;

            context.SaveChanges();
        }
    }
}
