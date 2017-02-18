using System;
using WebFormsMvp;

namespace CourseProject.Mvp.Account.Login
{
    public interface ILoginView : IView<LoginModel>
    {
        event EventHandler<LoginEventArgs> LoggingIn;
    }
}