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
    public ICollection<Wallet>? Wallets { get; set; }
    public ICollection<DeliveryAddress>? DeliveryAddresses { get; set; }
    public ICollection<Invoice>? Invoices { get; set; }
    public Basket? Basket { get; set; }

    public User(string username, string userpassword,string name, string surname,string phone,string email)
    {
        UserName = username;
        UserPassword = userpassword;
        Name = name;
        Surname = surname;
        Phone = phone;
        Email = email;
    }
}
