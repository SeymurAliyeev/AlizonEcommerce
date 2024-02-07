using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class Wallet:BaseEntities
{
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public decimal CardBalance { get; set; }
    public int UserId { get; set; } 
    public User User { get; set; } = null!; 
    public ICollection<Invoice>? Invoices { get; set; }

}
