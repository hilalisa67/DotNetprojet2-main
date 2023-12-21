using System;
using P2FixAnAppDotNetCode.Models.Repositories;

namespace P2FixAnAppDotNetCode.Models.Services
{
    public class OrderService : IOrderService
    {
       private readonly ICart _cart;
       private readonly IOrderRepository _repository;
       private readonly IProductService _productService;

        public OrderService(ICart cart, IOrderRepository orderRepo, IProductService productService)
        {
            _repository = orderRepo;
            _cart = cart;
            _productService = productService;
        }
        
        public void SaveOrder(Order order)
        {
            order.Date = DateTime.Now;
            _repository.Save(order);
            UpdateInventory();
        }
        
        private void UpdateInventory()
        {
            _productService.UpdateProductQuantities(_cart as Cart);
            _cart.Clear();
        }
    }
}
