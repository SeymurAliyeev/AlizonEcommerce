using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class Wallet:BaseEntities
{
    public string? CardName { get; set; }
    public string? CardNumber { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal? CardBalance { get; set; }
}
