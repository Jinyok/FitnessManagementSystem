using FMSystem.Entity.fms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMSystem.Entity.fms
{
    public partial class Member
    {
        //public Member()
        //{
        //    Instructs = new HashSet<Instructs>();
        //}

        public int MemberId { get; set; }
        public long? PhoneNo { get; set; }
        [Column(TypeName ="varchar(45)")]
        public string Name { get; set; }

        public virtual ICollection<Instructs> Instructs { get; set; }
        public virtual ICollection<Takes> Takes { get; set; }
    }
}
