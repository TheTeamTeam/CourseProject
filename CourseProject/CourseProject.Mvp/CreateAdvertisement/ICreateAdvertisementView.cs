using System;
using WebFormsMvp;

namespace CourseProject.Mvp.CreateAdvertisement
{
    public interface ICreateAdvertisementView : IView<CreateAdvertisementModel>
    {
        event EventHandler MyInit;

        event EventHandler<CreatingAdvertisementEventArgs> CreatingAdvertisement;
    }
}