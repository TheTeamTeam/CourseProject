using System.Web;
using CourseProject.Models;

namespace CourseProject.Web.Account.EventArguments
{
    public class SignInEventArgs
    {
        public SignInEventArgs(HttpContext context, User user)
        {
            // TODO: Gaurd

            this.Context = context;
            this.User = user;
        }

        public HttpContext Context { get; private set; }
        public User User { get; private set; }
    }
}