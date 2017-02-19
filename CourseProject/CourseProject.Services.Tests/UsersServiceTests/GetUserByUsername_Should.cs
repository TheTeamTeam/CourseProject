using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;

namespace CourseProject.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class GetUserByUsername_Should
    {
        [Test]
        public void CallRepositoryGetAllWithFilterMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();

            mockedUsersRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User>());

            var service = new UsersService(mockedUnitOfWork.Object,mockedUsersRepo.Object);

            service.GetUserByUsername("the-super-cool-username-007");

            mockedUsersRepo.Verify(
                x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>()), 
                Times.Once);
        }

        [Test]
        public void ReturnTheFounUser()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedUser = new Mock<User>();
            mockedUsersRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new List<User>() { mockedUser.Object });

            var service = new UsersService(mockedUnitOfWork.Object, mockedUsersRepo.Object);

            var result =service.GetUserByUsername("the-super-cool-username-007");

            Assert.AreEqual(mockedUser.Object, result);
        }
    }
}
