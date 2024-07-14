namespace Project 
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int HoursDonation { get; set; }
        public int HoursAvailable { get; set; } 
        public User(long id, string firstName, string lastName, string email, string address, int hoursDonation, int hoursAvailable)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            HoursDonation = hoursDonation;
            HoursAvailable = hoursAvailable;
        }
    }
}
