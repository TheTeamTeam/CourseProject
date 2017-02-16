using System.Linq;
using CourseProject.Data.Repositories;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Models;
using CourseProject.Services.Contracts;
using System;

namespace CourseProject.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<User> usersRepository;

        public UsersService(
            IUnitOfWork unitOfWork,
            IGenericRepository<User> usersRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null.");
            }

            if (usersRepository == null)
            {
                throw new ArgumentNullException("Users repository cannot be null.");
            }

            this.unitOfWork = unitOfWork;
            this.usersRepository = usersRepository;
        }

        public User GetUserById(string userId)
        {
            return this.usersRepository.GetById(userId);
        }

        public User GetUserByUsername(string username) //Not tested
        {
            // TODO: Find method in repostory ??
            return this.usersRepository.GetAll(x => x.UserName == username).FirstOrDefault();
        }

        public void AddAdToUpcoming(string userId, Advertisement ad)
        {
            using (this.unitOfWork)
            {
                var user = this.usersRepository.GetById(userId);
                user.UpcomingAds.Add(ad);
                this.unitOfWork.Commit();
            }
        }

        public void AddAdToSaved(string userId, Advertisement ad)
        {
            using (this.unitOfWork)
            {
                var user = this.usersRepository.GetById(userId);
                user.SavedAds.Add(ad);
                this.unitOfWork.Commit();
            }
        }

        public bool UserBookedAd(string userId, Advertisement ad)
        {
            var user = this.usersRepository.GetById(userId);

            return user.UpcomingAds.Contains(ad);
        }

        public bool UserSavedAd(string userId, Advertisement ad)
        {
            var user = this.usersRepository.GetById(userId);

            return user.SavedAds.Contains(ad);
        }

        public void RemoveAdFromSaved(int adId, User user)
        {
            using (this.unitOfWork)
            {
                var ad = user.SavedAds.SingleOrDefault(x => x.Id == adId);
                user.SavedAds.Remove(ad);
                this.unitOfWork.Commit();
            }
        }
    }
}