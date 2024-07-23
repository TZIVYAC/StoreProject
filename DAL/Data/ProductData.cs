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
    public class ProductData : IProductData
    {

        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public ProductData(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddProduct(ProductDto product)
        {
            _context.Product.Add(_mapper.Map<Product>(product));
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _context.Product.ToListAsync();
            return products;
        }

        public async Task<bool> DeleteProduct(long productId)
        {

            // Find the product by its Id
            var product = _context.Product.Find(productId);

            if (product != null)
            {
                // Remove the product from DbSet
                _context.Product.Remove(product);
                int changes = await _context.SaveChangesAsync();
                return changes > 0;
            }
            else
            {
                // Handle case where product with given Id is not found
                throw new ArgumentException("Product not found");
            }
        }


        public async Task<bool> UpdatePrice(ProductDto product)
        {
            _context.Product.Update(_mapper.Map<Product>(product));
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

    }
}
