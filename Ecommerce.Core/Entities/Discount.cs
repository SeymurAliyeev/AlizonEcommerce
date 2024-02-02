using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class Discount:BaseEntities
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal DiscountPercentage { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ICollection<Product> Products { get; set; } = null!;   
}
