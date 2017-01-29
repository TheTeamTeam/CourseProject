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

        public TestPresenter(ITestView view) : base(view)
        {
            View.Finding += Finding;
            this.people = new List<Person>
            {
                new Person {FirstName="Pesho", Age=5 },
                new Person {FirstName="Gosho", Age=10 }
            };
            View.Model.Person = this.people.First();
        }

        private void Finding(object sender, FindPersonEventArgs e)
        {
            var name = e.Name;
            View.Model.Person = this.people.FirstOrDefault(x => x.FirstName == name) ?? this.people.First();
        }
    }
}