using System;
using WebFormsMvp;
using CourseProject.Data.Repositories;
using CourseProject.Models;
using CourseProject.Web.Account.Views;
using CourseProject.Web.Account.EventArguments;

namespace CourseProject.Web.Account.Presenters
{
    public class ProfilePresenter : Presenter<IProfileView>
    {
        private IGenericRepository<User> usersRepository;

        public ProfilePresenter(IProfileView view, IGenericRepository<User> usersRepository)
            : base(view)
        {
            if (usersRepository == null)
            {
                throw new ArgumentNullException("Users repository cannot be null.");
            }

            this.usersRepository = usersRepository;

            this.View.GettingUser += OnGettingUser;
        }

        private void OnGettingUser(object sender, GetUserEventArgs e)
        {
            var user = this.usersRepository.GetById(e.Id);
            this.View.Model.ProfileUser = user;
        }
    }
}