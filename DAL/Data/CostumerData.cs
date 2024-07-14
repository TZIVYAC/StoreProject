using AutoMapper;
using DAL.DTO;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using MODELS.Models;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Data
{
    public class CostumerData : ICostumerData
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public CostumerData(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Costumer>> GetAllCostumers()
        {
            var costumers = await _context.Costumer.ToListAsync();
            return costumers;
        }

        public async Task<Costumer> GetCostumerById(long id)
        {
            var costumer = await _context.Costumer.FindAsync(id);
            return costumer;
        }

        public async Task<bool> AddCostumer(CostumerDto costumer)
        {
            _context.Costumer.Add(_mapper.Map<Costumer>(costumer));
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        //public async Task<bool> DeductAvailableHours(int hours, long Id)
        //{
        //    var donation = await _context.Donations.FindAsync(Id);
        //    if (donation == null)
        //    {
        //        return false; 
        //    }

        //    donation.HoursAvailable -= hours;
        //    if (donation.HoursAvailable <= 0)
        //    {
        //        return await DeleteDonation(Id);
        //    }

        //    int changes = await _context.SaveChangesAsync();
        //    return changes > 0;
        //}

        //public async Task<bool> DeleteDonation(long donationId)
        //{
        //    var donation = await _context.Donations.FindAsync(donationId);
        //    if (donation == null)
        //    {
        //        return false; 
        //    }

        //    _context.Donations.Remove(donation);
        //    int changes = await _context.SaveChangesAsync();
        //    return changes > 0;
        //}

        //public async Task<bool> RateDonation(long donationId, int rating)
        //{
        //    var donation = await _context.Donations.FindAsync(donationId);
        //    if (donation == null)
        //    {
        //        return false; 
        //    }
        //    donation.Rating = rating;
        //    int changes = await _context.SaveChangesAsync();
        //    return changes > 0;
        //}
    }
}
