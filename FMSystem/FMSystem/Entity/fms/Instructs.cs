using System;
using System.Collections.Generic;

namespace FMSystem.Entity.fms
{
    public partial class Instructs
    {
        public int MemberId { get; set; }
        public int CoachId { get; set; }
        public int AttendedHours { get; set; }
        public int TotalHours { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual Member Member { get; set; }
    }
}
