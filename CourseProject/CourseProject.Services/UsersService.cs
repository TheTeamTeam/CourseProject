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

        public void AddAdToUpcoming(string id, Advertisement Ad)
        {
            var user = this.usersRepository.GetById(id);
            user.UpcomingAds.Add(Ad);
            this.usersRepository.Update(user);
            this.unitOfWork.Commit();
        }
    }
}