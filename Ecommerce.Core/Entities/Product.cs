using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class Product:BaseEntities
{
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string Description { get; set; }
}
