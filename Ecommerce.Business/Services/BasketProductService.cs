using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;

namespace Ecommerce.Business.Services;

public class BasketProductService : IBasketProductServices
{
    private readonly AlizonDbContext _dbContext;
    public BasketProductService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async void AddProductToBasketAsync(int basketId, int productId, int quantity)
    {
        Basket? dbBasket = _dbContext.Baskets.FirstOrDefault(b => b.Id == basketId);
        if (dbBasket == null)
        {
            throw new NotFoundException($"{basketId} is not found");
        }

        Product? dbProduct = _dbContext.Products.FirstOrDefault(p => p.Id == productId);
        if (dbProduct == null)
        {
            throw new NotFoundException($"{productId} is not found");
        }

        var existingBasketProduct = _dbContext.BasketProducts.FirstOrDefault(bp => bp.BasketId == basketId && bp.ProductId == productId);

        if (existingBasketProduct != null)
        {
            existingBasketProduct.BasProCount += quantity;
        }
        else
        {
            var newBasketProduct = new BasketProduct
            {
                BasketId = basketId,
                ProductId = productId,
                BasProCount = quantity
            };

            await _dbContext.BasketProducts.AddAsync(newBasketProduct);
        }

        dbProduct.StockCount -= quantity;
        await _dbContext.SaveChangesAsync();
    }
}
