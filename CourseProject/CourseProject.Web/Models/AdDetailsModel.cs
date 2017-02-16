using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Web.Models
{
    public class AdDetailsModel
    {
        public Advertisement Advertisement { get; set; }

        public bool BookButtonVisible { get; set; }
        public bool SaveButtonVisible { get; set; }
    }
}