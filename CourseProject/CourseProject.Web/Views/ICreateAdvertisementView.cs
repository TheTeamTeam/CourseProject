using System;
using WebFormsMvp;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;

namespace CourseProject.Web.Views
{
    public interface ICreateAdvertisementView : IView<CreateAdvertisementModel>
    {
        event EventHandler MyInit;

        event EventHandler<CreatingAdvertisementEventArgs> CreatingAdvertisement;
    }
}