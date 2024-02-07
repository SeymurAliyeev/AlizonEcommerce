using Ecommerce.Core.Abstract;
using System.Security.Cryptography;

namespace Ecommerce.Core.Entities;

public class User : BaseEntities
{
    public string UserName { get; set; } = null!;
    public string UserPassword { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Surname { get; set; }
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool Role { get; set; } = false;
    public ICollection<Wallet>? Wallets { get; set; }
    public ICollection<DeliveryAddress>? DeliveryAddresses { get; set; }
    public ICollection<Invoice>? Invoices { get; set; }
    public Basket? Basket { get; set; }

}
