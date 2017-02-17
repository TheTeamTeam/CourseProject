using System;
using System.Web;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.EventArguments
{
    public class RoleEventArgs : EventArgs, IRoleEventArgs
    {
        public RoleEventArgs(string roleName, HttpContext context, string userId)
        {
            this.RoleName = roleName;
            this.Context = context;
            this.UserId = userId;
        }

        public string RoleName { get; set; }

        public HttpContext Context { get; set; }

        public string UserId { get; set; }
    }
}