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
            CreateMap<SectionCreateViewModel, Section>()
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

            CreateMap<Section, SectionViewModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(s => s.Course.Title));

            CreateMap<CoachViewModel, Coach>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(s => Enum.Parse(typeof(Coach.CoachState), s.State)))
                .ReverseMap()
                .ForMember(dest => dest.State, opt => opt.MapFrom(s => s.State.ToString()));

            CreateMap<CoachViewModel, Coach>()
                .ReverseMap();

            CreateMap<Lesson, LessonViewModel>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(s => s.StartDate.Value.ToUnixTimeSeconds()))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(s => s.EndDate.Value.ToUnixTimeSeconds()))
                .ForMember(dest => dest.State, opt => opt.MapFrom(s => s.State.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.StartDate)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.EndDate)))
                .ForMember(dest => dest.State, opt => opt.MapFrom(s => Enum.Parse(typeof(Lesson.LessonState), s.State)));
        }
    }
}
