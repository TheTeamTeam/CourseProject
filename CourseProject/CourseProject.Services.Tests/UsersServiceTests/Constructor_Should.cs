using System;
using NUnit.Framework;
using Moq;
using CourseProject.Data.Repositories;
using CourseProject.Models;
using CourseProject.Data.UnitsOfWork;

namespace CourseProject.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();

            Assert.Throws<ArgumentNullException>(() => new UsersService(null, mockedUsersRepo.Object));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenUnitOfWorkIsNull()
        {
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();

            Assert.That(() => new UsersService(null, mockedUsersRepo.Object),
                Throws.ArgumentNullException.With.Message.Contains("Unit of work cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUsersRepoIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() => new UsersService(mockedUnitOfWork.Object, null));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenUsersRepoIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.That(() => new UsersService(mockedUnitOfWork.Object, null),
                Throws.ArgumentNullException.With.Message.Contain("Users repository cannot be null."));
        }
    }
}
