using System;
using WebFormsMvp;
using CourseProject.Web.Views;
using CourseProject.Web.EventArguments;
using CourseProject.Services.Contracts;

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
        }

        private void OnGettingUser(object sender, GetUserByIdEventArgs e)
        {
            var user = this.usersService.GetUserById(e.Id);
            this.View.Model.ProfileUser = user;
        }
    }
}