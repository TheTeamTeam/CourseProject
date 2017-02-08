using CourseProject.Models;

namespace CourseProject.Services.Contracts
{
    public interface IUsersService
    {
        void AddAdToUpcoming(string id, Advertisement Ad);

        void AddAdToSaved(string id, Advertisement ad);

        bool UserBookedAd(string id, Advertisement ad);

        bool UserSavedAd(string id, Advertisement ad);
    }
}
