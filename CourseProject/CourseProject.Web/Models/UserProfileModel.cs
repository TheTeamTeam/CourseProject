﻿using System.Collections.Generic;
using CourseProject.Models;

namespace CourseProject.Web.Models
{
    public class UserProfileModel
    {
        public User ProfileUser { get; set; }

        public bool IsSeller { get; set; }
        public bool IsAdmin { get; set; }
    }
}