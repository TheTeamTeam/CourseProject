using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Web.EventArguments
{
    public class StringIdEventArgs : EventArgs
    {
        public StringIdEventArgs(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}