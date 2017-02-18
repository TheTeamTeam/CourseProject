using System;
using CourseProject.Models;

namespace CourseProject.Mvp.AdDetails
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