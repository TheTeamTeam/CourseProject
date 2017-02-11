using System;
using WebFormsMvp;
using CourseProject.Web.Models;
using CourseProject.Web.EventArguments;

namespace CourseProject.Web.Views
{
    public interface ISearchView : IView<SearchModel>
    {
        // TODO: Decide on naming convention for event handlers.

        event EventHandler Initializing;
        event EventHandler<SearchEventArgs> Searching;
    }
}