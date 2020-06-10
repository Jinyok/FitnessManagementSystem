using System;
using System.Collections.Generic;

namespace FMSystem.Models
{
    public partial class Course
    {
        public Course()
        {
            Section = new HashSet<Section>();
        }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
        public int ClassHour { get; set; }

        public virtual ICollection<Section> Section { get; set; }
    }
}
