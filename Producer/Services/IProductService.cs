using Producer.Models;

namespace Producer.Services
{
    public interface IProductService
    {
        public Product GetProductById(int id);
        public Product AddProduct(Product product);

    }
}
