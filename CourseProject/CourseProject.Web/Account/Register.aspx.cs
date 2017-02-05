using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Models;
using CourseProject.Web.Identity;
using CourseProject.Web.Account.Models;
using CourseProject.Web.Account.Views;
using CourseProject.Web.Account.EventArguments;
using CourseProject.Web.Account.Presenters;

namespace CourseProject.Web.Account
{
    [PresenterBinding(typeof(RegisterPresenter))]
    public partial class Register : MvpPage<RegisterModel>, IRegisterView
    {
        public event EventHandler<RegisterEventArgs> Registering;
        public event EventHandler<SignInEventArgs> SigningIn;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var user = new User()
            {
                UserName = UserName.Text,
                Email = Email.Text,
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Age = int.Parse(Age.Text)
            };

            this.Registering?.Invoke(this, new RegisterEventArgs(this.Context, user, this.Password.Text));

            if (this.Model.IdentityResult.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                this.SigningIn?.Invoke(this, new SignInEventArgs(this.Context, user));

                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = this.Model.IdentityResult.Errors.FirstOrDefault();
            }
        }
    }
}