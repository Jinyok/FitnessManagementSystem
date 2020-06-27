using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.ViewModels
{
    public class SectionViewModel
    {
        public int SectionId { get; set; }
        public int? CourseId { get; set; }
        public int CoachId { get; set; }
    }
}
