using System.Web;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using CourseProject.Mvp.Identity;

namespace CourseProject.Mvp.Account.Login
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view)
            : base(view)
        {
            this.View.LoggingIn += this.OnLoggingIn;
        }
        
        private void OnLoggingIn(object sender, LoginEventArgs e)
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