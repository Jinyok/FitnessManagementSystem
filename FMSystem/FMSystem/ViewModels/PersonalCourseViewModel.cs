using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.ViewModels
{
    public class PersonalCourseViewModel
    {
        public int MemberId { get; set; }
        public int CoachId { get; set; }
        public int AttendedHours { get; set; }
        public int TotalHours { get; set; }
    }
}
