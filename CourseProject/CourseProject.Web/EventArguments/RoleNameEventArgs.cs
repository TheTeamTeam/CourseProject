using System;
using System.Web;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.EventArguments
{
    public class RoleNameEventArgs : EventArgs, IRoleNameEventArgs
    {
        public RoleNameEventArgs(string roleName, HttpContext context)
        {
            this.RoleName = roleName;
            this.Context = context;
        }

        public string RoleName { get; set; }
        public HttpContext Context { get; set; }
    }
}