using System;
using WebFormsMvp;

namespace CourseProject.Mvp.Search
{
    public interface ISearchView : IView<SearchModel>
    {
        // TODO: Decide on naming convention for event handlers.
        event EventHandler Initializing;

        event EventHandler<SearchEventArgs> Searching;
    }
}