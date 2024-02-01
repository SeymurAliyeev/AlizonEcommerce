using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class Invoice:BaseEntities
{
    public DateTime PaymentTime { get; set; }
    public decimal? TotalPrice { get; set; }
}
