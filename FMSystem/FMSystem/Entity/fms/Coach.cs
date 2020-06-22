using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMSystem.Entity.fms
{
    public partial class Coach
    {
        //public Coach()
        //{
        //    Instructs = new HashSet<Instructs>();
        //}

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CoachId { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Name { get; set; }
        public long? PhoneNo { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Email { get; set; }

        public CoachState State { get; set; }
        public virtual ICollection<Instructs> Instructs { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<CourseArrangement> CourseArrangement { get; set; }

        public enum CoachState
        {
            InOffice = 0,
            LeaveOffice = 1
        }
    }
}
