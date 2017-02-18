using System;
using WebFormsMvp;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;

namespace CourseProject.Web.Views
{
    public interface IHomeView : IView<HomeModel>
    {
       event EventHandler<CountEventArgs> Initializing;
    }
}