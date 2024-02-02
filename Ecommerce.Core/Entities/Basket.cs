using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class Basket:BaseEntities
{
    public User User { get; set; } = null!;
    public int UserId { get; set; }
    public ICollection<BasketProduct>? BasketProducts { get; set; }
}
