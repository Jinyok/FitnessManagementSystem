using System;
using System.Collections.Generic;

namespace FMSystem.Models
{
    public partial class Section
    {
        public int SectionId { get; set; }
        public int? CourseId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Course Course { get; set; }
    }
}
