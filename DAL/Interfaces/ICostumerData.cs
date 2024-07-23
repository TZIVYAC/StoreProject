using DAL.DTO;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICostumerData
    {
        public Task<List<Costumer>> GetAllCostumers();
        public Task<Costumer> GetCostumerById(int id);
        public Task<bool> AddCostumer(CostumerDto user);
    }
}
