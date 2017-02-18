using System;

namespace CourseProject.Mvp.AdDetails
{
    public class AdDetailsEventArgs : EventArgs
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