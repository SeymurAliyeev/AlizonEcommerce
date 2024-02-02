using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class Category:BaseEntities
{
    public string Name { get; set; } = null!;
    public ICollection<Product>? Products { get; set; }
}
