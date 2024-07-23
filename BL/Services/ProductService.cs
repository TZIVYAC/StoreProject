using BL.Interfaces;
using DAL.Data;
using DAL.DTO;
using DAL.Interfaces;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ProductService:IProductService
    {
        private readonly ProductData _productData;
        public ProductService(ProductData productData)
        {
            _productData = productData;
        }
        public async Task<bool> AddProduct(ProductDto product)
        {
            return await _productData.AddProduct(product);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productData.GetAllProducts();
        }

        public async Task<bool> DeleteProduct(long productId)
        {
            return await _productData.DeleteProduct(productId);
        }

        public async Task<bool> UpdatePrice(ProductDto product)
        {
            return await _productData.UpdatePrice(product);
        }

    }
}
