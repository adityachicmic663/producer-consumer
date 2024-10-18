using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Producer.Models;
using Producer.RabbitMQ;
using Producer.Services;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRabbitMQProducer _rabbitMQProducer;

        public ProductController(IProductService productService, IRabbitMQProducer rabbitMQProducer)
        {
            _productService = productService;
            _rabbitMQProducer = rabbitMQProducer;
        }

        [HttpGet("getproductbyid")]
        public Product GetProductById(int Id)
        {
            return _productService.GetProductById(Id);
        }
        [HttpPost("addproduct")]
        public Product AddProduct(Product product)
        {
            var productData = _productService.AddProduct(product);
            //send the inserted product data to the queue and consumer will listening this data from queue
            _rabbitMQProducer.SendProductMessage(productData);
            return productData;
        }
    }
}
