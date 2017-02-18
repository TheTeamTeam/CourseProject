using System;
using System.Web;
using WebFormsMvp;
using CourseProject.Mvp.CommonEventArguments;

namespace CourseProject.Mvp.Users.AdminControls.ChangeRoles
{
    public interface IChangeRolesView : IView<ChangeRolesModel>
    {
        event EventHandler<StringIdEventArgs> GettingRoles;

        event EventHandler<RoleEventArgs> AddingRole;

        event EventHandler<RoleEventArgs> RemovingRole;

        HttpContext Context { get; }
    }
}
