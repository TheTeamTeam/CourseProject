using System;
using CourseProject.Models;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.EventArguments 
{
    public class BookAdEventArgs : EventArgs, IBookAdEventArgs
    {
        public BookAdEventArgs(string userId, Advertisement ad)
        {
            this.Id = userId;
            this.Ad = ad;
        }

        public string Id { get; private set; }

        public Advertisement Ad { get; private set; }
    }
}