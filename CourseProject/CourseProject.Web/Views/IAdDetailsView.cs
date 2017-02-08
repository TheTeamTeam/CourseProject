using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CourseProject.Web.Views
{
    public interface IAdDetailsView : IView<AdDetailsModel>
    {
        event EventHandler<AdDetailsEventArgs> MyInit;

        event EventHandler<BookAdEventArgs> Book;
    }
}