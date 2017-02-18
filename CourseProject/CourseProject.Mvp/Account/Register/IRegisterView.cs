using System;
using WebFormsMvp;

namespace CourseProject.Mvp.Account.Register
{
    public interface IRegisterView : IView<RegisterModel>
    {
        event EventHandler<RegisterEventArgs> Registering;    
    }
}
