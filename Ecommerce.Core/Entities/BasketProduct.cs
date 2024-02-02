using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class BasketProduct:BaseEntities
{
    public int BasProCount { get; set; }    
    public Basket Basket { get; set; } = null!;    
    public int BasketId { get; set; }    
    public Product Product { get; set; } = null!;    
    public int ProductId { get; set; }    
}
