using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.Entity.fms
{
    public class Lesson
    {
        public int SectionId { get; set; }
        
        public int LessonNo { get; set; }
        public int CoachId { get; set; }


        [Column(TypeName = "DATETIME")]
        public DateTimeOffset? StartDate { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTimeOffset? EndDate { get; set; }

        public LessonState State { get; set; }

        public enum LessonState
        {
            NotFinished=0,
            Finished = 1
        }
    }
}
