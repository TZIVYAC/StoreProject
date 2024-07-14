using DAL.DTO;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductData
    {
        public Task<List<Product>> GetAllProducts();
        public Task<bool> AddProduct(ProductDto donation);
        //public Task<bool> DeductAvailableHours(int hours, long Id);
        public Task<bool> DeleteProduct(long Id);
        //public Task<bool> RateDonation(long Id, int rating);
    }
}
