using DAL.DTO;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDonationData
    {
        public Task<List<Donation>> GetAllDonation();
        public Task<bool> AddDonation(DonationDto donation);
        public Task<bool> DeductAvailableHours(int hours, long Id);
        public Task<bool> DeleteDonation(long Id);
        public Task<bool> RateDonation(long Id, int rating);
    }
}
