using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class Product:BaseEntities
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int StockCount { get; set; }
    public Category Category { get; set; } = null!;
    public int CategoryId { get; set; }
    public Discount? Discount { get; set; }
    public int DiscountId { get; set; }
    public Brand Brand { get; set; } = null!;
    public int BrandId { get; set; }
    public ICollection<ProductInvoice>? ProductInvoices { get; set; }
    public ICollection<BasketProduct>? BasketProducts { get; set; }
}
