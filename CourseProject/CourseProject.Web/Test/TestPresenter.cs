using CourseProject.Data.Repositories;
using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CourseProject.Web.Test
{
    public class TestPresenter: Presenter<ITestView>
    {
        private ICollection<Person> people;

        private readonly IGenericRepository<User> usersRepository;

        public TestPresenter(ITestView view, IGenericRepository<User> usersRepository) 
            : base(view)
        {
            if(usersRepository == null)
            {
                throw new ArgumentNullException("Users repository cannot be null!");
            }

            this.usersRepository = usersRepository;
            this.View.GettingUsernames += OnGettingUsernames;

            this.View.Finding += Finding;
            this.people = new List<Person>
            {
                new Person {FirstName="Pesho", Age=5 },
                new Person {FirstName="Gosho", Age=10 }
            };
            View.Model.Person = this.people.First();
        }

        private void OnGettingUsernames(object sender, EventArgs e)
        {
            var usernames = this.usersRepository.Select(x => x.UserName).ToList();
            this.View.Model.Usernames = usernames;
        }

        private void Finding(object sender, FindPersonEventArgs e)
        {
            var name = e.Name;
            this.View.Model.Person = this.people.FirstOrDefault(x => x.FirstName == name) ?? this.people.First();
        }
    }
}