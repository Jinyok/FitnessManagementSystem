using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.Entity.fms
{
    public class Take
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int MemberId { get; set; }

    }
}
