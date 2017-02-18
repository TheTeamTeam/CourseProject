using System;
using System.Web;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.EventArguments
{
    public class GetUserByUsernameEventArgs : EventArgs, IGetUserByUsernameEventArgs
    {
        public GetUserByUsernameEventArgs(string username, HttpContext context)
        {
            this.Username = username;
            this.Context = context;
        }

        public string Username { get; private set; }

        public HttpContext Context { get; private set; }
    }
}