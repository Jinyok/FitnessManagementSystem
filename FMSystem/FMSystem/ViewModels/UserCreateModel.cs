using FMSystem.Entity.fms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.ViewModels
{
    public class UserCreateModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Number { get; set; }
        public string Role { get; set; }
    }
}
