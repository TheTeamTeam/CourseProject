using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CourseProject.Web.Test
{
    [PresenterBinding(typeof(TestPresenter))]
    public partial class TestControl : MvpUserControl<TestModel>, ITestView
    {
        public event EventHandler<FindPersonEventArgs> Finding;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            var name = this.NameBox.Text;
            Finding(this, new FindPersonEventArgs(name));
        }
    }
}