using System;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        
        private List<CartLine> _cartLines = new List<CartLine>();
        
        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            return _cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // Get the current cart lines
            var cartLines = GetCartLineList();

            // Check if the product already exists in the cart
            var cartLine = cartLines.FirstOrDefault(p => p.Product.Id == product.Id);

            Console.WriteLine(cartLine);
            if (cartLine != null)
            {
                // If the product exists, increment the quantity
                cartLine.Quantity += quantity;
            }
            else
            {
                // If the product does not exist, add a new CartLine
                cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            return Math.Round(GetCartLineList().Sum(e => e.Product.Price * e.Quantity), 2);
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            var countProducts =GetCartLineList().Sum(p=>p.Quantity);
            return GetTotalValue() / countProducts;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            return null;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
