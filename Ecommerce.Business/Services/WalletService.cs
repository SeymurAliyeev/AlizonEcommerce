using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Ecommerce.Business.Services;

public class WalletService : IWalletServices
{
    private readonly AlizonDbContext _dbContext;
    public WalletService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async void CreateAsync(string cardName, string cardNumber, decimal cardBalance, int uuserId)
    {
        if (String.IsNullOrEmpty(cardNumber)) throw new ArgumentNullException();
        Wallet dbWallet = await _dbContext.Wallets.FirstOrDefaultAsync(w => w.CardNumber.ToLower() == cardName.ToLower());
        if (dbWallet is not null)
            throw new AlreadyExistException($"{dbWallet.CardName} is already exist");

        User dbUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id != uuserId);
        if (dbUser is null)
            throw new NotFoundException($"{dbUser.Id} is not found");


        Wallet wallet = new()
        {
            CardName = cardName,
            CardNumber = cardNumber,
            CardBalance = cardBalance,
            UserId = uuserId
        };
        await _dbContext.Wallets.AddAsync(wallet);
        await _dbContext.SaveChangesAsync();
        Console.WriteLine($"{wallet} has successfully been added into your profile");
    }

    public void Delete(string cardNumber, int _userId)
    {
        User? dbUser = _dbContext.Users.FirstOrDefault(u => u.Id == _userId);
        if (dbUser == null)
        {
            throw new NotFoundException($"{_userId} is not found");
        }

        Wallet? dbWallet = _dbContext.Wallets.FirstOrDefault(w =>
            w.CardNumber.ToLower() == cardNumber.ToLower() && w.UserId == _userId);

        if (dbWallet == null)
        {
            throw new NotFoundException($"{cardNumber} is not found");
        }

        _dbContext.Wallets.Remove(dbWallet);
        _dbContext.SaveChanges();

        Console.WriteLine($"Wallet with the number of {cardNumber} is deleted");
    }

    public async void UpdateAsync(string cardNumber, int userId_, decimal amount)
    {
        var wallet = _dbContext.Wallets.FirstOrDefault(w => w.CardNumber.ToLower() == cardNumber.ToLower());

        if (wallet == null)
        {
            throw new NotFoundException($"{cardNumber} is not found");
        }

        if (wallet.UserId == userId_ && amount > 0)
        {
            wallet.CardBalance += amount;
            await _dbContext.SaveChangesAsync();
            Console.WriteLine($"Your balance has successfully been updated");
        }
    }

    public void ShowAllWallets(int userId)
    {
        foreach (Wallet wallet in _dbContext.Wallets)
        {
            wallet.isDelete = false;
            wallet.UserId = userId;
            Console.WriteLine($"{wallet.CardName};  {wallet.CardNumber};  {wallet.CardBalance};  {wallet.UserId};  {wallet.CreateTime};");
        }
    }
}
