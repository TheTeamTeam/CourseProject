using CourseProject.Web.Models;
using CourseProject.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using CourseProject.Web.EventArguments;
using WebFormsMvp;
using CourseProject.Web.Presenters;

namespace CourseProject.Web.Users.AdminControls
{
    [PresenterBinding(typeof(ChangeRolesPresenter))]
    public partial class ChangeRolesControl : MvpUserControl<ChangeRolesModel>, IChangeRolesView
    {
        public event EventHandler<RoleEventArgs> AddingRole;
        public event EventHandler<RoleEventArgs> RemovingRole;
        public event EventHandler<StringIdEventArgs> GettingRoles;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.GettingRoles?.Invoke(this, new StringIdEventArgs(this.UserId));
        }

        public string UserId { get; set; } 

        HttpContext IChangeRolesView.Context
        {
            get
            {
                return this.Context;
            }
        }

        // TODO: Should roles be constants / enum
        protected void MakeSellerBtn_Click(object sender, EventArgs e)
        {
            this.AddingRole?.Invoke(this, new RoleEventArgs("Seller", this.Context, this.UserId));
        }

        protected void MakeAdminBtn_Click(object sender, EventArgs e)
        {
            this.AddingRole?.Invoke(this, new RoleEventArgs("Admin", this.Context, this.UserId));
        }

        protected void RemoveSellerBtn_Click(object sender, EventArgs e)
        {
            this.RemovingRole?.Invoke(this, new RoleEventArgs("Seller", this.Context, this.UserId));
        }

        protected void RemoveAdminBtn_Click(object sender, EventArgs e)
        {
            this.RemovingRole?.Invoke(this, new RoleEventArgs("Admin", this.Context, this.UserId));
        }
    }
}