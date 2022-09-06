namespace NotesWebApi.Data.Interfaces
{
    public interface IPerson
    {
        int Id { get; set; }
        string Name { get; set; }
        string SurName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string Description { get; set; }
    }
}
