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
        public long StartDate { get; set; }
        public long EndDate { get; set; }
        public string State { get; set; }
    }
}
