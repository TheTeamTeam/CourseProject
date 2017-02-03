using CourseProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject.Web
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using(var context = new AdsHubDbContext())
            {
                var usernames = context.Users.Select(x=>x.Username).ToList();
                this.Sth.Text = string.Join(", ", usernames);
            }
        }
    }
}