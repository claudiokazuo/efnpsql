using Domain.Entities;
using Domain.Queries;
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
                new Person("Person A", "person.a@email.com"),
                new Person("Person B", "person.b@email.com"),
                new Person("Person C", "person.c@email.com"),
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
                .Returns((long id) => 
                    persons.AsQueryable()
                           .Where(EntityQuery<Person>.GetById(id))
                           .SingleOrDefault());
                

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
                        Person result = persons.AsQueryable()
                                               .Where(EntityQuery<Person>.GetById(person.Id))
                                               .SingleOrDefault();
                        persons.Remove(result);
                    });

            mockRepository
                .Setup(repository => repository.Update(It.IsAny<Person>()))
                .Callback<Person>(
                    person =>
                    {
                        Person result = persons.AsQueryable()
                                               .Where(EntityQuery<Person>.GetById(person.Id))
                                               .SingleOrDefault();

                        result.SetIsActive(person.IsActive);
                        result.SetUpdateOn(person.UpdatedOn);
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
            Person person = new Person("Person D", "person.d@email.com");

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

            personUpdated.SetUpdateOn(updateOnExpected);
            personUpdated.SetIsActive(isActiveExpeceted);

            _repository.Update(personUpdated);

            Person personFound = _repository.SearchById(id);

            Assert.Equal(updateOnExpected, personFound.UpdatedOn);
            Assert.Equal(isActiveExpeceted, personFound.IsActive);
        }
    }
}
