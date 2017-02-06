using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CourseProject.Web.Views
{
    public interface ICreateAdvertisementView : IView<CreateAdvertisementModel>
    {
        event EventHandler MyInit;
        event EventHandler<CreatingAdvertisementEventArgs> CreatingAdvertisement;
    }
}