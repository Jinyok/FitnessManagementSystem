﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.ViewModels
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public int Cost { get; set; }
        public int ClassHour { get; set; }
    }
}
