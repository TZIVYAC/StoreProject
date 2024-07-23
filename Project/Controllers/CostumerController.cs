using Microsoft.AspNetCore.Mvc;
using BL.Interfaces;
using DAL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CostumerController : ControllerBase
    {
        private readonly ICostumerService _costumerService;

        public CostumerController(ICostumerService costumerService)
        {
            _costumerService = costumerService;
        }

        [HttpGet("GetAllCostumers")]
        public async Task<ActionResult<List<Costumer>>> GetAllCostumers()
        {   
            var res = await _costumerService.GetAllCostumers();
            if (res.Count != 0)
                return Ok(res);
            return BadRequest();
        }

        [HttpGet("GetCostumerById/{id}")]
        public async Task<ActionResult<Costumer>> GetCostumerById(int id)
        {
            var res = await _costumerService.GetCostumerById(id);
            if (res != null)
                return Ok(res);
            return BadRequest();
        }

        [HttpPost("AddCostumer")]
        public async Task<ActionResult<bool>> AddCostumer(CostumerDto costumer)
        {
            var res = await _costumerService.AddCostumer(costumer);
            if (res)
                return Ok(res);
            return BadRequest();
        }

    }
}