using System;
using WebFormsMvp;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;
using System.Web;
using System.Security.Principal;

namespace CourseProject.Web.Views
{
    public interface IUserProfileView : IView<UserProfileModel>
    {
        event EventHandler<GetUserByUsernameEventArgs> GettingUser;
        event EventHandler<RoleEventArgs> AddingRole;
        event EventHandler<RoleEventArgs> RemovingRole;
        
        HttpServerUtility Server { get; }

        IPrincipal User { get; }
    }
}