using System.Web;

namespace CourseProject.Mvp.EventArgsContracts
{
    public interface IRoleEventArgs
    {
        HttpContext Context { get; set; }

        string RoleName { get; set; }
    }
}