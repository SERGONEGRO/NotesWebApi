using NotesWebApi.Data.Interfaces;

namespace NotesWebApi.Data.Models
{
    public class NullPerson:IPerson
    {
        public NullPerson()
        {
            this.Id = 0;
            this.Name = "null";
            this.SurName = "null";
            this.LastName = "null";
            this.PhoneNumber = "null";
            this.Address = "null";
            this.Description = "null";
        }

        static public NullPerson Create()
        {
            return new NullPerson();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
