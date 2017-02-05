using System;
using WebFormsMvp;
using CourseProject.Web.Account.EventArguments;
using CourseProject.Web.Account.Models;

namespace CourseProject.Web.Account.Views
{
    public interface IRegisterView : IView<RegisterModel>
    {
        event EventHandler<RegisterEventArgs> Registering;

        event EventHandler<SignInEventArgs> SigningIn;
    }
}
