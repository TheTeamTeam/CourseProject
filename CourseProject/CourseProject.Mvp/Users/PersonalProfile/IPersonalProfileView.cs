using System;
using WebFormsMvp;
using CourseProject.Mvp.CommonEventArguments;

namespace CourseProject.Mvp.Users.PersonalProfile
{
    public interface IPersonalProfileView : IView<PersonalProfileModel>
    {
        event EventHandler<GetUserByIdEventArgs> GettingUser;

        event EventHandler<IdEventArgs> RemovingSavedAd;
    }
}