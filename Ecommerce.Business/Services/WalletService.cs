using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;

namespace Ecommerce.Business.Services;

public class WalletService : IWalletServices
{
    private readonly AlizonDbContext _dbContext;
    public WalletService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(string cardName, string cardNumber, decimal cardBalance, int userId)
    {
        Wallet dbWallet = _dbContext.Wallets.FirstOrDefault(w => w.CardNumber.ToLower() == cardName.ToLower());
        throw new AlreadyExistException($"{cardName} is already exist");

        Wallet wallet = new();
        _dbContext.Wallets.Add(wallet);
        _dbContext.SaveChanges();
        Console.WriteLine($"{wallet} has successfully been added into your profile");
    }

    public void Delete(string cardNumber, int userId)
    {
        Wallet dbWallet = _dbContext.Wallets.FirstOrDefault(w => w.CardNumber.ToLower() != cardNumber.ToLower());
        throw new NotFoundException($"{cardNumber} is not found");

        foreach (Wallet wallet in _dbContext.Wallets)
        {
            wallet.CardNumber = cardNumber;
            wallet.UserId = userId;
            _dbContext.Wallets.Remove(wallet);
            _dbContext.SaveChanges();
            Console.WriteLine($"{wallet} is deleted");
        }
    }

    public void Update(string cardNumber, int userId, decimal amount)
    {
        Wallet dbWallet = _dbContext.Wallets.FirstOrDefault(w => w.CardNumber.ToLower() != cardNumber.ToLower());
        throw new NotFoundException($"{cardNumber} is not found");

        var wallet = _dbContext.Wallets.FirstOrDefault(w => w.CardNumber.ToLower() == cardNumber.ToLower());

        if (wallet.UserId == userId && amount>0)
        {
            wallet.CardBalance += amount;
            _dbContext.SaveChanges();
            Console.WriteLine($"Your balance has successfully been increased");
        }
    }
}
