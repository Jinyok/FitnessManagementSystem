﻿using System;
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
                .ReverseMap();

            CreateMap<CoachViewModel, Coach>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(s => Enum.Parse(typeof(Coach.CoachState), s.State)))
                .ReverseMap()
                .ForMember(dest => dest.State, opt => opt.MapFrom(s => s.State.ToString()));

            CreateMap<CourseViewModel, Course>()
                .ForMember(dest=>dest.Section,opt=>opt.Ignore())
                .ReverseMap();

            CreateMap<Lesson, LessonViewModel>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(s => s.StartDate.Value.ToUnixTimeSeconds()))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(s => s.EndDate.Value.ToUnixTimeSeconds()))
                .ForMember(dest => dest.State, opt => opt.MapFrom(s => s.State.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.StartDate)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.EndDate)))
                .ForMember(dest => dest.State, opt => opt.MapFrom(s => Enum.Parse(typeof(Lesson.LessonState), s.State)));

            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(s => s.Role.ToString()))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(s => s.CreateTime.Value.ToUnixTimeSeconds()))
                .ReverseMap()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(s => Enum.Parse(typeof(User.UserRole), s.Role)))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.CreateTime)));


            CreateMap<UserCreateModel, User>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(s => Enum.Parse(typeof(User.UserRole), s.Role)));

            CreateMap<PersonalCourseViewModel, Instructs>()
                .ReverseMap();
        }
    }
}
