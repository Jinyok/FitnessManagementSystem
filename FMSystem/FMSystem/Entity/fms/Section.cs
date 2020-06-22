using FMSystem.Entity.fms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMSystem.Entity.fms
{
    public partial class Section
    {
        public int SectionId { get; set; }
        public int? CourseId { get; set; }
        public int CoachId { get; set; }
        [Column(TypeName ="DATETIME")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime? EndDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual ICollection<Takes> Takes { get; set; }
    }
}
