using Domain.Entities;
using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.Test.Queries
{
    public class PersonQueryTest
    {
        private IList<Person> _persons;

        public PersonQueryTest()
        {
            _persons = new List<Person>()
            {
                new Person("Person A", "person.a@email.com"),
                new Person("Person B", "person.b@email.com"),
                new Person("Person C", "person.c@email.com"),
            };

            for (int i = 1; i <= _persons.Count(); i++)
            {
                _persons[i - 1].Id = i;
                _persons[i - 1].SetIsActive(i % 2 == 0 ? true : false);
                _persons[i - 1].SetUpdateOn(DateTime.Now.AddDays(i));
            }
        }

        [Fact]
        public void CanFindById()
        {
            int idExpected = 2;
            Person person = _persons.AsQueryable().Where(EntityQuery<Person>.GetById(idExpected)).SingleOrDefault();
            Assert.Equal(idExpected, person.Id);
        }

        [Fact]
        public void CanFindByCreatedOn()
        {
            int countExpected = 3;
            int countActual = _persons.AsQueryable().Where(EntityQuery<Person>.GetByCreatedOn(DateTime.Now)).Count();
            Assert.Equal(countExpected, countActual);
        }

        [Fact]
        public void CanFindByUpdateOn()
        {
            int countExpected = 1;
            DateTime updateOn = DateTime.Now.AddDays(2);
            int countActual = _persons.AsQueryable<Person>().Where(EntityQuery<Person>.GetByUpdateOn(updateOn)).Count();
            Assert.Equal(countExpected, countActual);
        }

        [Fact]
        public void CanFindInactivePersons()
        {
            int countExpected = 2;
            int countActual = _persons.AsQueryable().Where(EntityQuery<Person>.GetByIsActive(false)).Count();
            Assert.Equal(countExpected, countActual);
        }

        [Fact]
        public void CanFindActivePersons()
        {
            int countExpected = 1;
            int countActual = _persons.AsQueryable().Where(EntityQuery<Person>.GetByIsActive(true)).Count();
            Assert.Equal(countExpected, countActual);
        }
    }
}
