using BL.Interfaces;
using DAL.Data;
using DAL.DTO;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CostumerService:ICostumerService
    {
        private readonly CostumerData _costumerData;
        public CostumerService(CostumerData costumerData)
        {
            _costumerData = costumerData;
        }
        public async Task<List<Costumer>> GetAllCostumers()
        {
            return await _costumerData.GetAllCostumers();
        }
        public async Task<Costumer> GetCostumerById(int id)
        {
            return await _costumerData.GetCostumerById(id);
        }
        public async Task<bool> AddCostumer(CostumerDto costumer)
        {
            return await _costumerData.AddCostumer(costumer);
        }
    }
}
