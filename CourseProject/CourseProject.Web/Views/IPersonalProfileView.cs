using System;
using WebFormsMvp;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.Views
{
    public interface IPersonalProfileView : IView<PersonalProfileModel>
    {
        event EventHandler<IGetUserByIdEventArgs> GettingUser;

        event EventHandler<IdEventArgs> RemovingSavedAd;
    }
}