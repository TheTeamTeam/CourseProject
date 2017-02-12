using System.Web;

namespace CourseProject.Web.EventArguments.Contracts
{
    public interface IGetUserByUsernameEventArgs
    {
        HttpContext Context { get; }
        string Username { get; }
    }
}