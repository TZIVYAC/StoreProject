using DAL.DTO;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();
        public Task<bool> AddProduct(ProductDto product);
        public Task<bool> DeleteProduct(long productId);
        public Task<bool> UpdatePrice(ProductDto product);

    }
}
