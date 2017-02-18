using System;
using System.Web;

namespace CourseProject.Mvp.Users.AdminControls.ChangeRoles
{
    public class RoleEventArgs : EventArgs
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