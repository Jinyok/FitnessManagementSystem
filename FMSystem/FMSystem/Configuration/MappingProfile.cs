using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using FMSystem.Entity.fms;
using FMSystem.ViewModels;

namespace FMSystem.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SectionViewModel, Section>()
                .ForMember(dest => dest.Lesson, opt => opt.MapFrom<ICollection<Lesson>>((s, d) =>
                {
                    List<Lesson> lessons = new List<Lesson>();
                    int i = 1;
                    foreach (var x in s.TimeSlices)
                    {
                        lessons.Add(new Lesson
                        {
                            SectionId = s.SectionId,
                            LessonNo = i++,
                            CoachId = s.CoachId,
                            StartDate=DateTimeOffset.FromUnixTimeSeconds(x.StartTime),
                            EndDate=DateTimeOffset.FromUnixTimeSeconds(x.EndTime),
                            State=Lesson.LessonState.NotFinished
                        });
                    }
                    return lessons;
                }));

            CreateMap<CoachViewModel, Coach>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(s => Enum.Parse(typeof(Coach.CoachState), s.State)))
                .ForMember(dest=>dest.PhoneNo,opt=>opt.MapFrom(s=>long.Parse(s.PhoneNo)));
        }
    }
}
