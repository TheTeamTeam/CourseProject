using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Web.EventArguments
{
    public class CreatingAdvertisementEventArgs : EventArgs
    {
        public CreatingAdvertisementEventArgs(Advertisement advertisement)
        {
            this.Advertisement = advertisement;
        }

        public Advertisement Advertisement { get; private set; }
    }
}