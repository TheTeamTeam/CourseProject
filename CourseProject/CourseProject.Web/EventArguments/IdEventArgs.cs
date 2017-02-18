using System;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.EventArguments
{
    public class IdEventArgs : EventArgs, IIdEventArgs
    {
        public IdEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}