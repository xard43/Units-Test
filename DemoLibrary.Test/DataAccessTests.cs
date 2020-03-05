using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DemoLibrary;
using DemoLibrary.Models;

namespace DemoLibrary.Test
{
    public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_shouldWork()
        {
            PersonModel newPerson = new PersonModel { FirstName = "Marek", LastName = "Nazwisko" };
            List<PersonModel> people = new List<PersonModel>();

            DataAccess.AddPersonToPeopleList(people, newPerson);

            Assert.True(people.Count == 1);
            Assert.Contains<PersonModel>(newPerson, people);
        }

        [Theory]
        [InlineData("Marek", "", "LastName")]
        [InlineData("", "Nazwisko", "FirstName")]
        public void AddPersonToPeopleList_shouldFail(string firstname, string lastName, string param)
        {
            PersonModel newPerson = new PersonModel { FirstName = firstname, LastName = lastName };
            List<PersonModel> people = new List<PersonModel>();

            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));

        }
        [Fact]
        public void ConvertModelsToCSV_shouldWork()
        {
            List<PersonModel> people = new List<PersonModel>();
            PersonModel newPerson = new PersonModel { FirstName = "Marek", LastName = "Nazwisko" };
            PersonModel newPerson2 = new PersonModel { FirstName = "Marek2", LastName = "Nazwisko2" };
            PersonModel newPerson3 = new PersonModel { FirstName = "Marek3", LastName = "Nazwisko3" };
            people.Add(newPerson);
            people.Add(newPerson2);
            people.Add(newPerson3);

            List<string> output = DataAccess.ConvertModelsToCSV(people);

            Assert.True(output.Count == 3);
            Assert.Contains<string>("Marek,Nazwisko", output);
            Assert.Contains<string>("Marek2,Nazwisko2", output);
            Assert.Contains<string>("Marek3,Nazwisko3", output);
        }

        
    }
}
