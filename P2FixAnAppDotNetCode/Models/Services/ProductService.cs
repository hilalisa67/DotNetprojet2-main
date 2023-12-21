using System.Collections.Generic;
using System.Linq;
using P2FixAnAppDotNetCode.Models.Repositories;

namespace P2FixAnAppDotNetCode.Models.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
        
        public Product GetProductById(int id)
        {
            return _productRepository.GetAllProducts().FirstOrDefault(p => p.Id == id);
        }
        
        public void UpdateProductQuantities(Cart cart)
        {
            foreach (var line in cart.Lines)
            {
                var product = line.Product;
                _productRepository.UpdateProductStocks(product.Id, line.Quantity);
            }
        }
    }
}
