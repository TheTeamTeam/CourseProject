using System;

namespace CourseProject.Web.Account.EventArguments
{
    public class GetUserEventArgs : EventArgs
    {
        public GetUserEventArgs(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}