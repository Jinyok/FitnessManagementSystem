using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMSystem.Entity.fms
{
    public partial class Course
    {
        //public Course()
        //{
        //    Section = new HashSet<Section>();
        //}

        public int CourseId { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Title { get; set; }
        public int Cost { get; set; }
        public int ClassHour { get; set; }

        public virtual ICollection<Section> Section { get; set; }
        public virtual ICollection<CourseArrangement> CourseArrangement { get; set; }
    }
}
