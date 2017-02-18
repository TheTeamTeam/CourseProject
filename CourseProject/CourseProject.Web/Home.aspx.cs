using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Mvp.Home;

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