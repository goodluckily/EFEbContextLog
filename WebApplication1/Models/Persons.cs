namespace WebApplication1.Models
{
    public class Person
    {
        public long PersonId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public Address? Address { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
