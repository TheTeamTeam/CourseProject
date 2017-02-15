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

namespace CourseProject.Web
{
    [PresenterBinding(typeof(HomePresenter))]
    public partial class Home : MvpPage<HomeModel>, IHomeView
    {
        public event EventHandler<CountEventArgs> Initializing;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Initializing?.Invoke(this, new CountEventArgs(5));
        }
    }
}