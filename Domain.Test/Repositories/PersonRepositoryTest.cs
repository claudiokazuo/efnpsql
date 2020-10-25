using Domain.Entities;
using Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.Test.Repositories
{
    public class PersonRepositoryTest
    {
        private IRepository<Person> _repository;

        public PersonRepositoryTest()
        {
            IList<Person> persons = new List<Person>()
            {
                new Person("Person A", "person.a@email.com", true),
                new Person("Person B", "person.b@email.com", true),
                new Person("Person C", "person.c@email.com", true),
            };

            for (int i = 1; i <= persons.Count(); i++)
            {
                persons[i - 1].Id = i;
            }

            Mock<IRepository<Person>> mockRepository = new Mock<IRepository<Person>>();

            mockRepository
               .Setup(repository => repository.GetAll())
               .Returns(persons);

            mockRepository
                .Setup(repository => repository.SearchById(It.IsAny<long>()))
                .Returns((long id) => persons.Where(person => person.Id == id).Single());

            mockRepository
                .Setup(repository => repository.Add(It.IsAny<Person>()))
                .Callback<Person>(
                    person =>
                    {
                        person.Id = persons.Count() + 1;
                        persons.Add(person);
                    });

            mockRepository
                .Setup(repository => repository.Remove(It.IsAny<Person>()))
                .Callback<Person>(
                    person =>
                    {
                        Person result = persons.Where(p => p.Equals(person)).SingleOrDefault();
                        persons.Remove(result);
                    });

            mockRepository
                .Setup(repository => repository.Update(It.IsAny<Person>()))
                .Callback<Person>(
                    person =>
                    {
                        Person result = persons.Where(p => p.Id == person.Id).SingleOrDefault();
                        result.IsActive = person.IsActive;
                        result.UpdatedOn = person.UpdatedOn;
                    });

            _repository = mockRepository.Object;
        }
        [Fact]
        public void CanReturnPersonsList()
        {
            IList<Person> persons = _repository.GetAll();
            Assert.NotNull(persons);
        }

        [Fact]
        public void CanAddPerson()
        {
            Person person = new Person("Person D", "person.d@email.com", true);

            int countExpected = _repository.GetAll().Count() + 1;

            _repository.Add(person);

            int countActual = _repository.GetAll().Count();

            Assert.Equal(countExpected, countActual);
        }

        [Fact]
        public void CanFindAPerson()
        {
            int id = 2;
            Person person = _repository.SearchById(id);
            Assert.Equal(id, person.Id);
        }

        [Fact]
        public void CanRemoveAPerson()
        {
            int id = 3;
            Person person = _repository.SearchById(id);
            Assert.Equal(id, person.Id);

            int countExpected = _repository.GetAll().Count() - 1;

            _repository.Remove(person);

            int countActual = _repository.GetAll().Count();

            Assert.Equal(countExpected, countActual);
        }

        [Fact]
        public void CanUpdateAPerson()
        {
            int id = 1;

            DateTime updateOnExpected = DateTime.Now;
            bool isActiveExpeceted = false;

            Person personUpdated = _repository.SearchById(id);

            Assert.Equal(id, personUpdated.Id);

            personUpdated.UpdatedOn = updateOnExpected;
            personUpdated.IsActive = isActiveExpeceted;

            _repository.Update(personUpdated);

            Person personFound = _repository.SearchById(id);

            Assert.Equal(updateOnExpected, personFound.UpdatedOn);
            Assert.Equal(isActiveExpeceted, personFound.IsActive);
        }
    }
}
