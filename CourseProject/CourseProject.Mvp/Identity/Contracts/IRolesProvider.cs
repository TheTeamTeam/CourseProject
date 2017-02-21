using System.Collections.Generic;
using System.Web;

namespace CourseProject.Mvp.Identity.Contracts
{
    public interface IRolesProvider
    {
        IEnumerable<string> GetRoles(HttpContext context, string userId); 
    }
}
