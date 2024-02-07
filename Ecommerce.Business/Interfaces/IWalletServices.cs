namespace Ecommerce.Business.Interfaces;

public interface IWalletServices
{
    void CreateAsync(string cardName, string cardNumber, decimal cardBalance, int uuserId);
    void Delete(string cardNumber, int userid);
    void Update(string cardNumber, int userId_, decimal amount);
    void ShowAllWallets(int userId);
}
