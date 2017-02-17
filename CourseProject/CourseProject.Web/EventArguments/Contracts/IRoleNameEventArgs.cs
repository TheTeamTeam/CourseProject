using System.Web;

namespace CourseProject.Web.EventArguments.Contracts
{
    public interface IRoleEventArgs
    {
        HttpContext Context { get; set; }
        string RoleName { get; set; }
    }
}