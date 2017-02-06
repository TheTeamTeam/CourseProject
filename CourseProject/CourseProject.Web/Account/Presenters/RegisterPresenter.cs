using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using CourseProject.Web.Account.EventArguments;
using CourseProject.Web.Account.Views;
using CourseProject.Web.Identity;

namespace CourseProject.Web.Account.Presenters
{
    public class RegisterPresenter : Presenter<IRegisterView>
    {
        public RegisterPresenter(IRegisterView view)
            :base(view)
        {
            this.View.Registering += OnRegistering;
            this.View.SigningIn += OnSigningIn;
        }

        private void OnRegistering(object sender, RegisterEventArgs e)
        {
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = e.Context.GetOwinContext().Get<ApplicationSignInManager>();
            
            IdentityResult result = manager.Create(e.User, e.Password);
            
            if (result.Succeeded)
            {
                manager.AddToRole(e.User.Id, "Regular");
            }

            this.View.Model.IdentityResult = result;
        }

        private void OnSigningIn(object sender, SignInEventArgs e)
        {
            var signInManager = e.Context.GetOwinContext().Get<ApplicationSignInManager>();

            // TODO: Should parameters come from view
            signInManager.SignIn(e.User, isPersistent: false, rememberBrowser:false);
        }
    }
}