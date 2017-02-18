using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using CourseProject.Web.Account.EventArguments;
using CourseProject.Web.Account.Views;
using CourseProject.Web.Identity;
using CourseProject.Models;

namespace CourseProject.Web.Account.Presenters
{
    public class RegisterPresenter : Presenter<IRegisterView>
    {
        public RegisterPresenter(IRegisterView view)
            : base(view)
        {
            this.View.Registering += this.OnRegistering;
        }

        private void OnRegistering(object sender, RegisterEventArgs e)
        {
            var user = new User()
            {
                UserName = e.UserName,
                Email = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Age = e.Age
            };

            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = e.Context.GetOwinContext().Get<ApplicationSignInManager>();

            IdentityResult result = manager.Create(user, e.Password);

            if (result.Succeeded)
            {
                manager.AddToRole(user.Id, "Regular");
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
            }

            this.View.Model.IdentityResult = result;
        }
    }
}