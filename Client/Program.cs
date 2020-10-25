using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {            
            Person entity = new Person(
                "Person Name",
                "personemail@email.com",               
                true);

            GenericContext<Person> genericContext = new GenericContext<Person>();
            
            IRepository<Person> repository = new GenericRepository<Person>(genericContext);
                        
            repository.Add(entity);

            IList<Person> persons = repository.GetAll();

            foreach (var person in persons)
            {
                Console.WriteLine($"Name: {person.Name} Email:{person.Email}");
            }

            Console.ReadKey();

        }
    }
}
