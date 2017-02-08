using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Web.EventArguments
{
    public class RoleNameEventArgs :EventArgs
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