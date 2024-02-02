using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class DeliveryAddress:BaseEntities
{
    public string City { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? PostalCode { get; set; }
    public User User { get; set; }=null!;
    public int UserId { get; set; }
}
