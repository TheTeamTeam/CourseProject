using System;
using System.Web;
using WebFormsMvp.Web;
using CourseProject.Web.EventArguments;
using WebFormsMvp;
using CourseProject.Web.Models;
using CourseProject.Web.Presenters;
using CourseProject.Web.Views;

namespace CourseProject.Web.Users.AdminControls
{
    [PresenterBinding(typeof(ChangeRolesPresenter))]
    public partial class ChangeRolesControl : MvpUserControl<ChangeRolesModel>, IChangeRolesView
    {
        public event EventHandler<RoleEventArgs> AddingRole;

        public event EventHandler<RoleEventArgs> RemovingRole;

        public event EventHandler<StringIdEventArgs> GettingRoles;

        public string UserId { get; set; } 

        HttpContext IChangeRolesView.Context
        {
            get
            {
                return this.Context;
            }
        }
        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.GettingRoles?.Invoke(this, new StringIdEventArgs(this.UserId));
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