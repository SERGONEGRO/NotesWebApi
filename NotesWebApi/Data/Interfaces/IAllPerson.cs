using NotesWebApi.Models;
using System.Collections.Generic;

namespace NotesWebApi.Data.Interfaces
{
    public interface IAllPerson
    {
        IEnumerable<Person> GetPersons { get; }
        Person GetPersonById(int id);
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int id);
        public IEnumerable<Person> GetPersonsRange(int pos, int count);
    }
}
