using System;

namespace CourseProject.Mvp.Users.PersonalProfile
{
    // TODO: maybe combine the other id event args
    public class GetUserByIdEventArgs : EventArgs
    {
        public GetUserByIdEventArgs(string id, bool isSeller)
        {
            this.Id = id;
            this.IsSeller = isSeller;
        }

        public string Id { get; private set; }

        public bool IsSeller { get; private set; }
    }
}