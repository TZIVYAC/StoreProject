using System.ComponentModel.DataAnnotations;

namespace Project 
{
    public class Costumer
    {
        [Key]
        public string Id { get; set; }
        public int IdEntity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
     
        public Costumer(string id,int idEntity, string firstName, string lastName, string email, string address)
        {
            Id = id;
            IdEntity = idEntity;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }
    }
}
