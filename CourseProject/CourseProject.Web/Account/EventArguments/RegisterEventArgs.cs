using System.Web;
using CourseProject.Models;

namespace CourseProject.Web.Account.EventArguments
{
    public class RegisterEventArgs
    {
        public RegisterEventArgs(HttpContext context, User user, string password)
        {
            // TODO: Gaurd

            this.Context = context;
            this.User = user;
            this.Password = password;
        }
        
        public HttpContext Context { get; private set; }
        public User User {get; private set; }
        public string Password {get; private set; }
    }
}