using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;

namespace Ecommerce.Business.Services;

public class BasketService : IBasketServices
{
    private readonly AlizonDbContext _dbContext;
    public BasketService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async void CreateAsync(int _userId)
    {
        User dbUser = _dbContext.Users.FirstOrDefault(u => u.Id != _userId);
        if (dbUser is null)
        throw new NotFoundException($"User with the ID of {dbUser.Id} is not found");

        User? _user = _dbContext.Users.FirstOrDefault(u => u.Id == _userId);

        var basket = new Basket
        {
            UserId = _userId,
            User = _user,
            BasketProducts = new List<BasketProduct>()
        };
        await _dbContext.Baskets.AddAsync(basket);
        await _dbContext.SaveChangesAsync();
    }

    public void Delete(int _basketId)
    {
        Basket dbBasket = _dbContext.Baskets.FirstOrDefault(b => b.Id != _basketId);
        throw new NotFoundException($"{_basketId} is not found");

        Basket basket = _dbContext.Baskets.FirstOrDefault(b => b.Id == _basketId);
        _dbContext.Baskets.Remove(basket);
        _dbContext.SaveChanges();
        Console.WriteLine($"Basket with the ID of {_basketId} has been deleted");
    }

    public async void ShowAllBasketsAsync(int userId)
    {
        foreach (Basket basket in _dbContext.Baskets)
        {
            basket.isDelete = false;
            basket.UserId = userId;
            Console.WriteLine($"{basket.Id};  {basket.BasketProducts};  {basket.UserId};");
        }
    }
}
