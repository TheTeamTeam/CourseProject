using System.Web;

namespace CourseProject.Mvp.EventArgsContracts
{
    public interface IGetUserByUsernameEventArgs
    {
        HttpContext Context { get; }

        string Username { get; }
    }
}