using System;
using System.Web;
using System.Web.ModelBinding;
using WebFormsMvp;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;

namespace CourseProject.Web.Views
{
    public interface IAdDetailsView : IView<AdDetailsModel>
    {
        event EventHandler<AdDetailsEventArgs> Initializing;

        event EventHandler<BookAdEventArgs> BookAd;

        event EventHandler<SaveAdEventArgs> SaveAd;

        event EventHandler<IdEventArgs> DeleteAd;

        event EventHandler<IdEventArgs> UpdateAd;

        HttpResponse Response { get; }

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}