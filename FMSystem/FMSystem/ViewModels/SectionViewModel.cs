using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.ViewModels
{
    public class SectionViewModel
    {
        public int SectionId { get; set; }
        public string Title { get; set; }
        public int ClassHour { get; set; }
        public int AttendedHours { get; set; }
    }
}
