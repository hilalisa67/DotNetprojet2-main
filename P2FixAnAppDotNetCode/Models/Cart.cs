using System;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    public class Cart : ICart
    {

        private readonly List<CartLine> _cartLines;

        public Cart()
        {
            _cartLines = new List<CartLine>();
        }
        
        public IEnumerable<CartLine> Lines => GetCartLineList();
        
        private List<CartLine> GetCartLineList()
        {
            return _cartLines;
        }
        
        public void AddItem(Product product, int quantity)
        {
            var cartLine = _cartLines.FirstOrDefault(p => p.Product.Id == product.Id);

            if (cartLine != null)
            {
                cartLine.Quantity += quantity;
                
                if (cartLine.Quantity == 0)
                {
                    RemoveLine(product);
                }
            }
            else
            {
                _cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
        }
        
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);
        
        public double GetTotalValue()
        {
            return Math.Round(GetCartLineList().Sum(e => e.Product.Price * e.Quantity), 2);
        }
        
        public double GetAverageValue()
        {
            var countProducts =GetCartLineList().Sum(p=>p.Quantity);
            return countProducts == 0 ? 0 : GetTotalValue() / countProducts;
        }
        
        public Product FindProductInCartLines(int productId)
        {
            return GetCartLineList().FirstOrDefault(p => p.Product.Id == productId)?.Product;
        }
        
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }
        
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
