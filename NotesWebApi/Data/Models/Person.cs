using NotesWebApi.Data.Interfaces;

namespace NotesWebApi.Models
{
    public class Person : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public string FullName
        {
            get { return SurName + " " + Name + " " + LastName; }
        }
    }
}
