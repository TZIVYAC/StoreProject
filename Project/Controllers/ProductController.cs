using BL.Interfaces;
using DAL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Controllers
{
     //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult<bool>> AddProduct([FromBody] ProductDto product)
        {
            var res = await _productService.AddProduct(product);
            if (res)
                return Ok(res);
            return BadRequest();
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var res = await _productService.GetAllProducts();
            if (res.Count != 0)
                return Ok(res);
            return BadRequest();
        }

        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<bool>> DeleteProduct([FromQuery] long productId)
        {
            var res = await _productService.DeleteProduct(productId);
            if (res)
                return Ok(res);
            return BadRequest();
        }

        [HttpPut("UpdatePrice")]
        public async Task<ActionResult<bool>> UpdatePrice([FromQuery] ProductDto p)
        {
            var res = await _productService.UpdatePrice(p);
            if (res)
                return Ok(res);
            return BadRequest();
        }

    }
}