using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Web.EventArguments
{
    public class CountEventArgs : EventArgs
    {
        public CountEventArgs(int count)
        {
            this.Count = count;
        }

        public int Count { get; private set; }
    }
}