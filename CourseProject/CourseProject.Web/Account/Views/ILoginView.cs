using System;
using WebFormsMvp;
using CourseProject.Web.Account.Models;
using CourseProject.Web.Account.EventArguments;

namespace CourseProject.Web.Account.Views
{
    public interface ILoginView : IView<LoginModel>
    {
        event EventHandler<LoginEventArgs> LoggingIn;
    }
}