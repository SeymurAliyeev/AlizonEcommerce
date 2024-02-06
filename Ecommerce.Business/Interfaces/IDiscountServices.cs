namespace Ecommerce.Business.Interfaces;

public interface IDiscountServices
{
    decimal GetDiscountedPrice(string productName, decimal discountpercentage);
}
