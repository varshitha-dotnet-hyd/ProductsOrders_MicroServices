using ProductService.Models;

namespace ProductService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 70000 },
            new Product { Id = 2, Name = "Mobile Phone", Price = 30000}
        };
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            Product product = _products.FirstOrDefault(x => x.Id == id);
            return product;
        }
    }
}
