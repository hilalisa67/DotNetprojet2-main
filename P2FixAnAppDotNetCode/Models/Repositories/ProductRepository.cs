using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products;

        public ProductRepository()
        {
            if (_products != null) return;
            _products = new List<Product>();
            GenerateProductData();

        }
        
        private void GenerateProductData()
        {
            int id = 0;
            _products.Add(new Product(++id, 10, 92.50, "Echo Dot", "(2nd Generation) - Black"));
            _products.Add(new Product(++id, 20, 9.99, "Anker 3ft / 0.9m Nylon Braided", "Tangle-Free Micro USB Cable"));
            _products.Add(new Product(++id, 30, 69.99, "JVC HAFX8R Headphone", "Riptidz, In-Ear"));
            _products.Add(new Product(++id, 40, 32.50, "VTech CS6114 DECT 6.0", "Cordless Phone"));
            _products.Add(new Product(++id, 50, 895.00, "NOKIA OEM BL-5J", "Cell Phone "));
        }
        
        public List<Product> GetAllProducts()
        {
            var products = _products.OrderBy(p => p.Name).ToList();
            return products;
        }
        
        public void UpdateProductStocks(int productId, int quantityToRemove)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.Stock -= quantityToRemove;
            }           
        }
    }
}
