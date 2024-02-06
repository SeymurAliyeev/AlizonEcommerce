namespace Ecommerce.Business.Interfaces;

public interface IWalletServices
{
    void Create(string cardName, string cardNumber, decimal cardBalance, int userId);
    void Delete(string cardNumber, int userId);
    void Update(string cardNumber, int userId, decimal amount);
}
