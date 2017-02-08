using CourseProject.Models;

namespace CourseProject.Services.Contracts
{
    public interface IUsersService
    {
        void AddAdToUpcoming(string id, Advertisement Ad);

        bool UserBookedAd(string id, Advertisement ad);
    }
}
