namespace Project
{
    public class Donation
    {
        public long Id { get; set; }
        public long DonorId { get; set; }
        public string DonationCategory { get; set; }
        public int HoursAvailable { get; set; }
        public int Rating { get; set; } 

        public Donation(long id, long donorId, string donationCategory, int hoursAvailable, int rating)
        {
            Id = id;
            DonorId = donorId;
            DonationCategory = donationCategory;
            HoursAvailable = hoursAvailable;
            Rating = rating;
        }

        public Donation() { }
    }
}
