using System.Web;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using CourseProject.Web.Account.Views;
using CourseProject.Web.Account.EventArguments;
using CourseProject.Web.Identity;

namespace CourseProject.Web.Account.Presenters
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view)
            : base(view)
        {
            this.View.LoggingIn += OnLoggingIn;
        }

        //TODO: remove public
        public void OnLoggingIn(object sender, LoginEventArgs e)
        {
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = e.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            // This doen't count login failures towards account lockout
            // To enable password failures to trigger lockout, change to shouldLockout: true
            var result = signinManager.PasswordSignIn(e.UserName, e.Password, e.RememberMe, e.ShouldLockOut);

            this.View.Model.SignInStatus = result;
        }
    }
}