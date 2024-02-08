namespace Ecommerce.Business.Interfaces;

public interface IBasketProductServices
{
    void AddProductToBasketAsync(int basketId,int productId,int quantity);
}
