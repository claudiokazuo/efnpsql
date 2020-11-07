using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {            
            Person entity = new Person(
                Guid.NewGuid().ToString("n").Substring(0, 8),
                $"{Guid.NewGuid().ToString("n").Substring(0, 16)}@email.com");

            GenericContext<Person> genericContext = new GenericContext<Person>();
            
            IRepository<Person> repository = new GenericRepository<Person>(genericContext);
                        
            repository.Add(entity);

            IList<Person> persons = repository.GetAll();

            foreach (var person in persons)
            {
                Console.WriteLine($"Id: {person.Id}\t Name: {person.Name}\t Email:{person.Email}");
            }

            Console.ReadKey();

        }
    }
}
