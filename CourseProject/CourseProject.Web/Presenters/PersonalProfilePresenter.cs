using System;
using WebFormsMvp;
using CourseProject.Web.Views;
using CourseProject.Web.EventArguments;
using CourseProject.Services.Contracts;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.Presenters
{
    public class PersonalProfilePresenter : Presenter<IPersonalProfileView>
    {
        private IUsersService usersService;

        public PersonalProfilePresenter(IPersonalProfileView view, IUsersService usersService)
            : base(view)
        {
            if (usersService == null)
            {
                throw new ArgumentNullException("Users service cannot be null.");
            }

            this.usersService = usersService;

            this.View.GettingUser += OnGettingUser;
            this.View.RemovingSavedAd += OnRemovingSavedAd;
        }

        private void OnRemovingSavedAd(object sender, IdEventArgs e)
        {
            this.usersService.RemoveAdFromSaved(e.Id, this.View.Model.ProfileUser);
        }

        private void OnGettingUser(object sender, IGetUserByIdEventArgs e)
        {
            var user = this.usersService.GetUserById(e.Id);
            this.View.Model.ProfileUser = user;
        }
    }
}