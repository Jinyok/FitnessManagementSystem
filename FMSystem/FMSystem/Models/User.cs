using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMSystem.Models
{
    public partial class User
    {
        [Column(TypeName ="varchar(20)")]
        public string Userid { get; set; }
        [Column(TypeName ="varchar(100)")]
        [Required]
        public string Password { get; set; }
        [Column(TypeName ="date")]
        public DateTime? CreateTime { get; set; }
    }
}
