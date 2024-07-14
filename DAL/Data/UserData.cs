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
using System.Threading.Tasks;
namespace DAL.Data
{
    public class UserData : IUserData
    {

        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public UserData(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(long id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<bool> AddUser(UserDto user)
        {
            _context.Users.Add(_mapper.Map<User>(user));
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }
        public async Task<bool> AddHoursDonation(int hours, long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            user.HoursDonation += hours;
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }
        public async Task<bool> RemoveHoursAvailable(int hours, long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            if((user.HoursAvailable - hours) < 0)
                return false;
            user.HoursAvailable -= hours;
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

    }
}
