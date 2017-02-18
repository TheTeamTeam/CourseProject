using CourseProject.Models;

namespace CourseProject.Services.Contracts
{
    public interface IUsersService
    {
        User GetUserById(string userId);

        User GetUserByUsername(string username);

        void AddAdToUpcoming(string userId, Advertisement ad);

        void AddAdToSaved(string userId, Advertisement ad);

        bool UserBookedAd(string userId, Advertisement ad);

        bool UserSavedAd(string userId, Advertisement ad);

        void RemoveAdFromSaved(int adId, User user);
    }
}
