using System;
using CourseProject.Web.EventArguments.Contracts;


namespace CourseProject.Web.EventArguments
{
    public class AdDetailsEventArgs : EventArgs, IAdDetailsEventArgs
    {
        public int Id { get; private set; }

        public AdDetailsEventArgs(int id)
        {
            this.Id = id;
        }
    }
}