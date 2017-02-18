using System;
using System.Web;
using System.Security.Principal;
using WebFormsMvp;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;

namespace CourseProject.Web.Views
{
    public interface IUserProfileView : IView<UserProfileModel>
    {
        event EventHandler<GetUserByUsernameEventArgs> GettingUser;
        
        HttpServerUtility Server { get; }

        IPrincipal User { get; }
    }
}