using Domain.Entities;
using Domain.Repositories;
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

            IGenericRepository<Person> personRepository = 
                new PersonRepository<Person>();            
            IGenericRepository<Domain.Entities.Document> documentRepository = 
                new DocumentRepository<Domain.Entities.Document>();
            IGenericRepository<DocumentType> documentTypeRepository =
                new GenericRepository<Domain.Entities.DocumentType>();
                        
            //personRepository.Add(entity);                       

            IList<Person> persons = personRepository.GetAll();
            IList<Domain.Entities.Document> documents = documentRepository.GetAll();
            IList<DocumentType> documentTypes = documentTypeRepository.GetAll();

            foreach (var person in persons)
            {
                Console.WriteLine($"Id: {person.Id}\t Name: {person.Name}\t Email:{person.Email}");
            }

            Console.ReadKey();

        }
    }
}
