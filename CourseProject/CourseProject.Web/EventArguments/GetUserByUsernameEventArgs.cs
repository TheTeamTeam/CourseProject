using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Web.EventArguments
{
    public class GetUserByUsernameEventArgs : EventArgs
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