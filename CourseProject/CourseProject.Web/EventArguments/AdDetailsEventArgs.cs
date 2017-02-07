using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Web.EventArguments
{
    public class AdDetailsEventArgs : EventArgs
    {
        public int Id { get; private set; }

        public AdDetailsEventArgs(int id)
        {
            this.Id = id;
        }
    }
}