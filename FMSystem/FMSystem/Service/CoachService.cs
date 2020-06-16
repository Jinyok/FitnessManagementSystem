using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMSystem.Controllers;
using FMSystem.Entity;
using FMSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace FMSystem.Service
{
    public class CoachService
    {
        private fmsContext context;
        public void Initialize(IServiceProvider serviceProvider)
        {
            context = new fmsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<fmsContext>>());
        }
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
            if (coach.CoachId > 0)
            {
                context.Coach.Add(coach);
                context.SaveChanges();
            }
            return;
        }

        public void DeleteCoach(int id)
        {
            context.Coach.Remove(GetCoachesById(id));
            context.SaveChanges();
        }

        public void UpdateCoach(Coach coach)
        {
            Coach temp = context.Coach.Find(coach.CoachId);
            if (temp == null)
                return;

            temp.CoachId = coach.CoachId;

            temp.Name = coach.Name;

            temp.Email = coach.Email;

            temp.PhoneNo = coach.PhoneNo;

            context.SaveChanges();
        }
    }
}
