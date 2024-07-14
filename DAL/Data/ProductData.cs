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
            _context.Product.Remove(_mapper.Map<Product>(productId));
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        //public async Task<bool> AddHoursDonation(int hours, long id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return false;
        //    }
        //    user.HoursDonation += hours;
        //    int changes = await _context.SaveChangesAsync();
        //    return changes > 0;
        //}
        //public async Task<bool> RemoveHoursAvailable(int hours, long id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return false;
        //    }
        //    if((user.HoursAvailable - hours) < 0)
        //        return false;
        //    user.HoursAvailable -= hours;
        //    int changes = await _context.SaveChangesAsync();
        //    return changes > 0;
        //}

    }
}
