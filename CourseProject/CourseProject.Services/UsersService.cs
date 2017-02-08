using CourseProject.Services.Contracts;
using CourseProject.Data.Repositories;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Models;
using System.Collections.Generic;
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
            // TODO: Gaurd
            this.unitOfWork = unitOfWork;
            this.usersRepository = usersRepository;
        }

        public void AddAdToUpcoming(string id, Advertisement ad)
        {
            using (this.unitOfWork)
            {
                var user = this.usersRepository.GetById(id);
                user.UpcomingAds.Add(ad);
                this.usersRepository.Update(user);
                this.unitOfWork.Commit();
            }
        }

        public void AddAdToSaved(string id, Advertisement ad)
        {
            using (this.unitOfWork)
            {
                var user = this.usersRepository.GetById(id);
                user.SavedAds.Add(ad);
                this.usersRepository.Update(user);
                this.unitOfWork.Commit();
            }
        }

        public bool UserBookedAd(string id, Advertisement ad)
        {
            var user = this.usersRepository.GetById(id);

            return user.UpcomingAds.Contains(ad);
        }

        public bool UserSavedAd(string id, Advertisement ad)
        {
            var user = this.usersRepository.GetById(id);

            return user.SavedAds.Contains(ad);
        }
    }
}