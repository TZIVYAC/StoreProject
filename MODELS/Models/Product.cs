namespace Project
{
    public class Product
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int Price { get; set; }
        public string ProductName { get; set; }

        public Product(long id, long productId, string productName, int price)
        {
            Id = id;
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }

        public Product() { }
    }
}
