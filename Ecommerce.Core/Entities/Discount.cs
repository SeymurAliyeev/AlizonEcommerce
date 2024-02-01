using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class Discount:BaseEntities
{
    public decimal? DiscountPercentage { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }   
}
