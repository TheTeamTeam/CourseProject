using System.Web;
using CourseProject.Models;

namespace CourseProject.Web.Account.EventArguments
{
    public class RegisterEventArgs
    {
        public RegisterEventArgs(
            HttpContext context,
            string userName,
            string email,
            string firstName,
            string lastName,
            int age,
            string password)
        {
            this.Context = context;
            this.UserName = userName;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Password = password;
        }

        public HttpContext Context { get; private set; }

        public string UserName { get; private set; }

        public string Email { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public string Password { get; private set; }
    }
}