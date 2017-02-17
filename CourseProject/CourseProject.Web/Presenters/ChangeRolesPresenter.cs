using CourseProject.Web.EventArguments;
using CourseProject.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using WebFormsMvp;
using CourseProject.Web.Identity;

namespace CourseProject.Web.Presenters
{
    public class ChangeRolesPresenter : Presenter<IChangeRolesView>
    {
        public ChangeRolesPresenter(IChangeRolesView view) : base(view)
        {
            this.View.GettingRoles += this.OnGettingRoles;
            this.View.AddingRole += this.OnAddingRole;
            this.View.RemovingRole += this.OnRemovingRole;
        }

        private void OnGettingRoles(object sender, StringIdEventArgs e)
        {
            var manager = this.View.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roles = manager.GetRoles(e.Id);

            this.View.Model.IsAdmin = roles.Contains("Admin");
            this.View.Model.IsSeller = roles.Contains("Seller");
        }

        private void OnAddingRole(object sender, RoleEventArgs e)
        {
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.AddToRole(e.UserId, e.RoleName);
            if (e.RoleName == "Admin")
            {
                this.View.Model.IsAdmin = true;
            }
            else
            {
                this.View.Model.IsSeller = true;
            }
        }

        private void OnRemovingRole(object sender, RoleEventArgs e)
        {
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.RemoveFromRole(e.UserId, e.RoleName);
            if (e.RoleName == "Admin")
            {
                this.View.Model.IsAdmin = false;
            }
            else
            {
                this.View.Model.IsSeller = false;
            }
        }
    }
}