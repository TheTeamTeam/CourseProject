using System;
using CourseProject.Models;

namespace CourseProject.Mvp.AdDetails
{
    public class SaveAdEventArgs : EventArgs
    {
        public SaveAdEventArgs(string userId, Advertisement ad)
        {
            this.Id = userId;
            this.Ad = ad;
        }

        public string Id { get; private set; }

        public Advertisement Ad { get; private set; }
    }
}