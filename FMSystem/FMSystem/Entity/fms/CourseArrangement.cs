using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.Entity.fms
{
    public class CourseArrangement
    {
        public int CourseId { get; set; }
        public int CourseNo { get; set; }
        public int CoachId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndTime { get; set; }
        
        public virtual Course Course { get; set; }
        public virtual Coach Coach { get; set; }
    }
}
