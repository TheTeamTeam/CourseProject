using System;
using WebFormsMvp;

namespace CourseProject.Mvp.Home
{
    public interface IHomeView : IView<HomeModel>
    {
       event EventHandler<CountEventArgs> Initializing;
    }
}