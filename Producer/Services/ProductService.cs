using Producer.Models;

namespace Producer.Services
{
    public class ProductService:IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public Product GetProductById(int id)
        {
            return _context.products.FirstOrDefault(x => x.productId == id);
        }
        public Product AddProduct(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
            return product;
        }

    }
}
