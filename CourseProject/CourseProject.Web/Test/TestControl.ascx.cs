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
        public event EventHandler GettingUsernames;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GettingUsernames?.Invoke(sender, e);
            //GettingUsernames(this, new EventArgs());
            this.UsernamesLiteral.Text = string.Join(", ", this.Model.Usernames);
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            var name = this.NameBox.Text;
            this.Finding?.Invoke(sender, new FindPersonEventArgs(name));
            //Finding(this, new FindPersonEventArgs(name));
        }
    }
}