using NotesWebApi.Data.Interfaces;
using NotesWebApi.Data.Models;
using NotesWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace NotesWebApi.Data.Repository
{
    public class PersonRepository : IAllPerson
    {
        //переменная для работы с файлос AppDBContent
        private readonly AppDBContent appDBContent;

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public PersonRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public void AddPerson(Person person)
        {
            Person newPerson = new Person()
            {
                Name = person.Name,
                SurName = person.SurName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
                Address = person.Address,
                Description = person.Description
            };
            appDBContent.Person.Add(newPerson);

            appDBContent.SaveChanges();
        }

        /// <summary>
        /// получаем всех клиентов
        /// </summary>
        public IEnumerable<Person> GetPersons => appDBContent.Person;

        public Person GetPersonById(int id) => appDBContent.Person.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Person> GetPersonsRange(int pos, int count)
            => appDBContent.Person.Where(person => person.Id >= pos && person.Id < pos + count);

        /// <summary>
        /// Редактировать клиента
        /// </summary>
        /// <param name="order"></param>
        public void UpdatePerson(Person newPerson)
        {
            Person OldPerson = GetPersonById(newPerson.Id);
            if (OldPerson != null)
            {
                OldPerson.Name = newPerson.Name;
                OldPerson.SurName = newPerson.SurName;
                OldPerson.LastName = newPerson.LastName;
                OldPerson.PhoneNumber = newPerson.PhoneNumber;
                OldPerson.Address = newPerson.Address;
                OldPerson.Description = newPerson.Description;

                appDBContent.Person.Update(OldPerson);

                appDBContent.SaveChanges();
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="person"></param>
        public void DeletePerson(int id)
        {
            appDBContent.Person.Remove(GetPersonById(id));
            appDBContent.SaveChanges();
        }
    }
}
