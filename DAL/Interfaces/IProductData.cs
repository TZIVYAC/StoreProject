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
        public Task<bool> DeleteProduct(long productId);
        public Task<bool> UpdatePrice(ProductDto product);
    }
}
