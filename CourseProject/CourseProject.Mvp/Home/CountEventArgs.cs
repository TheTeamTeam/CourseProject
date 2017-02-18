using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Mvp.Home
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