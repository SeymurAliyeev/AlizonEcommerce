namespace Ecommerce.Business.Interfaces;

public interface IBasketProductServices
{
    void AddProductToBasket(int basketId,int productId,int quantity);
}
