using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.ViewModels
{
    public class LessonViewModel
    {
        public int SectionId { get; set; }
        public int LessonNo { get; set; }
        public int CoachId { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public string State { get; set; }
    }
}
