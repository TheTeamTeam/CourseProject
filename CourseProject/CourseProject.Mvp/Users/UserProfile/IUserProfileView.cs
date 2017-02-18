using System;
using System.Web;
using System.Security.Principal;
using WebFormsMvp;

namespace CourseProject.Mvp.Users.UserProfile
{
    public interface IUserProfileView : IView<UserProfileModel>
    {
        event EventHandler<GetUserByUsernameEventArgs> GettingUser;
        
        HttpServerUtility Server { get; }

        IPrincipal User { get; }
    }
}