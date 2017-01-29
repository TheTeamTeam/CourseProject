using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace CourseProject.Web.Test
{
    public interface ITestView : IView<TestModel>
    {
        event EventHandler<FindPersonEventArgs> Finding;
    }
}
