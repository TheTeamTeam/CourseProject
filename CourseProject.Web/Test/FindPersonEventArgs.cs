using System;

namespace CourseProject.Web.Test
{
    public class FindPersonEventArgs : EventArgs
    {
        public FindPersonEventArgs()
        {
        }

        public FindPersonEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}