using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Presenters;
using CourseProject.Web.Models;
using CourseProject.Web.Views;

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