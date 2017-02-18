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
            var userName = this.UserName.Text;
            var email = this.Email.Text;
            var firstName = this.FirstName.Text;
            var lastName = this.LastName.Text;
            var age = int.Parse(this.Age.Text);
            var password = this.Password.Text;

            this.Registering?.Invoke(this, new RegisterEventArgs(
                this.Context, 
                userName,
                email,
                firstName,
                lastName,
                age, 
                password));

            if (this.Model.IdentityResult.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // string code = manager.GenerateEmailConfirmationToken(user.Id);
                // string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                // manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");              

                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], this.Response);
            }
            else
            {
                this.ErrorMessage.Text = this.Model.IdentityResult.Errors.FirstOrDefault();
            }
        }
    }
}