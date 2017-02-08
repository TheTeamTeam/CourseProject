using System;

namespace CourseProject.Web.EventArguments
{
    public class GetUserByIdEventArgs : EventArgs
    {
        public GetUserByIdEventArgs(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}