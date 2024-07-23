using DAL.DTO;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ICostumerService
    {
        public Task<List<Costumer>> GetAllCostumers();
        public Task<Costumer> GetCostumerById(int id);
        public Task<bool> AddCostumer(CostumerDto costumer);
        //public Task<bool> AddHoursDonation(int hours, long id);
        //public Task<bool> RemoveHoursAvailable(int hours, long id);
    }
}
