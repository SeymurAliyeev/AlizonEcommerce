using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class ProductInvoice:BaseEntities
{
    public int InvProCount { get; set; }
    public decimal InvProPrice { get; set; }
    public decimal DiscountApplied { get; set; }
    public Product Product { get; set; } = null!;
    public int ProductId { get; set; }
    public Invoice Invoice { get; set; } = null!;
    public int InvoiceId { get; set; }
}
