using System.ComponentModel.DataAnnotations;

namespace P2FixAnAppDotNetCode.Models
{
  public class Product
  {
      public Product(int id, int stock, double price, string name, string description)
    {
      Id = id;
      Stock = stock;
      Price = price;
      Name = name;
      Description = description;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Details { get; set; }

    public int Stock { get; set; }
    
    [DataType(DataType.Currency)]
    public double Price { get; set; }
  }
}
