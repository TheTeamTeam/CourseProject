using System.Web;

namespace CourseProject.Web.EventArguments.Contracts
{
    public interface IRoleNameEventArgs
    {
        HttpContext Context { get; set; }
        string RoleName { get; set; }
    }
}