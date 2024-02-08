namespace Ecommerce.Business.Interfaces;

public interface IBasketServices
{
    void CreateAsync(int _userId);
    void Delete(int _userId);
    void ShowAllBasketsAsync(int userId);

}
