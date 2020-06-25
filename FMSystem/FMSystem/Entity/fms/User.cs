using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMSystem.Entity.fms
{
    public partial class User
    {

        [Key]
        public long Userid { get; set; }



        [Column(TypeName = "varchar(30)")]
        [Required]
        public string UserName { get; set; }



        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Password { get; set; }


        [Required]
        public UserRole Role { get; set; }



        [Column(TypeName = "datetime")]
        public DateTimeOffset? CreateTime { get; set; }

        public enum UserRole
        {
            Root = 0,
            Admin = 1,
            Coach = 2,
            Clerk = 3,
            Member = 4,
        }
    }
}
