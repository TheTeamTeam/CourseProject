using System;
using System.Web;
using WebFormsMvp;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;

namespace CourseProject.Web.Views
{
    public interface IChangeRolesView : IView<ChangeRolesModel>
    {
        event EventHandler<StringIdEventArgs> GettingRoles;

        event EventHandler<RoleEventArgs> AddingRole;

        event EventHandler<RoleEventArgs> RemovingRole;

        HttpContext Context { get; }
    }
}
