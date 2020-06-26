using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.ViewModels
{
    public class SectionCreateViewModel
    {
        [BindNever]
        public int SectionId { get; set; }
        public int CourseId { get; set; }
        public int CoachId { get; set; }
        public List<TimeSlice> TimeSlices { get; set; }
    }
}
