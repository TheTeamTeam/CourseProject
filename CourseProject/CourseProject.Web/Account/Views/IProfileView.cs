using System;
using WebFormsMvp;
using CourseProject.Web.Account.EventArguments;
using CourseProject.Web.Account.Models;

namespace CourseProject.Web.Account.Views
{
    public interface IProfileView : IView<ProfileModel>
    {
        event EventHandler<GetUserEventArgs> GettingUser;
    }
}