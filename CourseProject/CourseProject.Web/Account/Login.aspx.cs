using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Web.Identity;
using CourseProject.Web.Account.Views;
using CourseProject.Web.Account.Models;
using CourseProject.Web.Account.EventArguments;
using CourseProject.Web.Account.Presenters;

namespace CourseProject.Web.Account
{
    [PresenterBinding(typeof(LoginPresenter))]
    public partial class Login : MvpPage<LoginModel>, ILoginView
    {
        public event EventHandler<LoginEventArgs> LoggingIn;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                this.LoggingIn?.Invoke(this, new LoginEventArgs(this.Context, this.UserName.Text, this.Password.Text, this.RememberMe.Checked, shouldLockOut: false));

                switch (this.Model.SignInStatus)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}