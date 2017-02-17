using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebFormsMvp;

namespace CourseProject.Web.Views
{
    public interface IChangeRolesView : IView<ChangeRolesModel>
    {
        HttpContext Context { get; }

        event EventHandler<StringIdEventArgs> GettingRoles;
        event EventHandler<RoleEventArgs> AddingRole;
        event EventHandler<RoleEventArgs> RemovingRole;
    }
}
