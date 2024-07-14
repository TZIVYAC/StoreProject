using BL.Interfaces;
using DAL.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Controllers
{
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

        //[HttpPost("DeductAvailableHours")]
        //public async Task<ActionResult<bool>> DeductAvailableHours([FromQuery] int hours, [FromQuery] long id)
        //{
        //    var res = await _donationService.DeductAvailableHours(hours, id);
        //    if (res)
        //        return Ok(res);
        //    return BadRequest();
        //}

        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<bool>> DeleteProduct([FromQuery] long productId)
        {
            var res = await _productService.DeleteProduct(productId);
            if (res)
                return Ok(res);
            return BadRequest();
        }

        //[HttpPost("RateDonation")]
        //public async Task<ActionResult<bool>> RateDonation([FromQuery] long donationId, [FromQuery] int rating)
        //{
        //    var res = await _donationService.RateDonation(donationId, rating);
        //    if (res)
        //        return Ok(res);
        //    return BadRequest();
        //}
    }
}