using CourseProject.Models;

namespace CourseProject.Services.Contracts
{
    public interface IUsersService
    {
        User GetUserById(string id);

        User GetUserByUsername(string username);

        void AddAdToUpcoming(string id, Advertisement Ad);

        void AddAdToSaved(string id, Advertisement ad);

        bool UserBookedAd(string id, Advertisement ad);

        bool UserSavedAd(string id, Advertisement ad);

        void RemoveAdFromSaved(int id, User user);
    }
}
