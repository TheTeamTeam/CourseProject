using System;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.EventArguments
{
    // TODO: maybe combine the other id event args
    public class GetUserByIdEventArgs : EventArgs, IGetUserByIdEventArgs
    {
        public GetUserByIdEventArgs(string id, bool isSeller)
        {
            this.Id = id;
            this.IsSeller = isSeller;
        }

        public string Id { get; private set; }

        public bool IsSeller{get; private set;}
    }
}