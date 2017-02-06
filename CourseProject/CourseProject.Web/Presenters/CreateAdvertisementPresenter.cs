using WebFormsMvp;
using CourseProject.Data.Repositories;
using CourseProject.Models;
using CourseProject.Services.Contracts;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Views;

namespace CourseProject.Web.Presenters
{
    public class CreateAdvertisementPresenter : Presenter<ICreateAdvertisementView>
    {
        private IAdvertisementsService adsService;

        public CreateAdvertisementPresenter(ICreateAdvertisementView view, IAdvertisementsService adsService) 
            : base(view)
        {
            this.adsService = adsService;

            this.View.CreatingAdvertisement += OnCreatingAdvertisement;
        }

        private void OnCreatingAdvertisement(object sender, CreatingAdvertisementEventArgs e)
        {
            this.adsService.CreateAdvertisement(e.Advertisement);
        }
    }
}