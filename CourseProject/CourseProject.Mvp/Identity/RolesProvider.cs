using System.Collections.Generic;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using CourseProject.Mvp.Identity.Contracts;

namespace CourseProject.Mvp.Identity
{
    public class RolesProvider : IRolesProvider
    {
        public IEnumerable<string> GetRoles(HttpContext context, string userId)
        {
            var manager = context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roles = manager.GetRoles(userId);
            return roles;
        }
    }
}
