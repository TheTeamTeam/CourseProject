using System;
using WebFormsMvp;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;

namespace CourseProject.Web.Views
{
    public interface IPersonalProfileView : IView<PersonalProfileModel>
    {
        event EventHandler<GetUserByIdEventArgs> GettingUser;

        event EventHandler<IdEventArgs> RemovingSavedAd;
    }
}