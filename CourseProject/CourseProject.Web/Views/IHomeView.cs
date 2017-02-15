using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CourseProject.Web.Views
{
    public interface IHomeView : IView<HomeModel>
    {
       event EventHandler<CountEventArgs> Initializing;
    }
}