using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class ProductDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int Price { get; set; }
        public string ProductName { get; set; }
    }
}
