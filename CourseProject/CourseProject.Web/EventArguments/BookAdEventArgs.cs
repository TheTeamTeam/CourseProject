using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Web.EventArguments 
{
    public class BookAdEventArgs : EventArgs
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