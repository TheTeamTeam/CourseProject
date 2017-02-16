using System;
using WebFormsMvp;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;

namespace CourseProject.Web.Views
{
    public interface IUserProfileView : IView<UserProfileModel>
    {
        event EventHandler<GetUserByUsernameEventArgs> GettingUser;
        event EventHandler<RoleNameEventArgs> AddingRole;
        event EventHandler<RoleNameEventArgs> RemovingRole;
    }
}