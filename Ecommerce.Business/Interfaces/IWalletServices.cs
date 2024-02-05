namespace Ecommerce.Business.Interfaces;

public interface IWalletServices
{
    void Create(string _CardName, string _CardNumber, decimal _CardBalance, int _UserId);
    void Delete(string cardNumber, int userId);
    void Update(int CardId);
}
