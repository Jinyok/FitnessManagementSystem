using FMSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.Entity.fms
{
    public class Takes
    {
        public int SectionId { get; set; }
        public int MemberId { get; set; }

        public virtual Section Section { get; set; }
        public virtual Member Member { get; set; }
    }
}
