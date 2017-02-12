using System;
using CourseProject.Models;
using CourseProject.Web.EventArguments.Contracts;


namespace CourseProject.Web.EventArguments
{
    public class CreatingAdvertisementEventArgs : EventArgs, ICreatingAdvertisementEventArgs
    {
        public CreatingAdvertisementEventArgs(Advertisement advertisement)
        {
            this.Advertisement = advertisement;
        }

        public Advertisement Advertisement { get; private set; }
    }
}