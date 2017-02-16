using System;
using CourseProject.Web.EventArguments.Contracts;


namespace CourseProject.Web.EventArguments
{
    public class AdDetailsEventArgs : EventArgs, IAdDetailsEventArgs
    {
        public AdDetailsEventArgs(int adId, string userId)
        {
            this.AdId = adId;
            this.UserId = userId;
        }

        public int AdId { get; private set; }

        public string UserId { get; private set; }     
    }
}