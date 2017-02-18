using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace CourseProject.Web.Views
{
    public interface IAdDetailsView : IView<AdDetailsModel>
    {
        event EventHandler<AdDetailsEventArgs> Initializing;

        event EventHandler<BookAdEventArgs> BookAd;

        event EventHandler<SaveAdEventArgs> SaveAd;

        event EventHandler<IdEventArgs> DeleteAd;

        event EventHandler<IdEventArgs> UpdateAd;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;

        HttpResponse Response { get; }
    }
}