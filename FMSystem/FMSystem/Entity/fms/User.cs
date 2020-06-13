using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMSystem.Models
{
    public partial class User
    {
        [Column(TypeName ="varchar(30)")]
        [Key]
        [BindNever]
        public string Userid { get; set; }

        [Column(TypeName ="varchar(30)")]
        public string UserName { get; set; }

        [Column(TypeName ="varchar(100)")]
        [Required]
        public string Password { get; set; }
        [Column(TypeName ="date")]
        public DateTime? CreateTime { get; set; }
    }
}
