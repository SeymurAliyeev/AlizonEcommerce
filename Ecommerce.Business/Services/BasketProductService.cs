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

    public void AddProductToBasket(int basketId, int productId, int quantity)
    {
        Basket dbBasket = _dbContext.Baskets.FirstOrDefault(b => b.Id != basketId);
        throw new NotFoundException($"{basketId} is not found");

        Product dbProduct = _dbContext.Products.FirstOrDefault(p => p.Id != productId);
        throw new NotFoundException($"{productId} is not found");

        var basket = _dbContext.Baskets.Find(basketId);
        var product = _dbContext.Products.Find(productId);

        if (basket != null && product != null && quantity <= product.StockCount)
        {

            var existingBasketProduct = _dbContext.BasketProducts.FirstOrDefault(bp => bp.ProductId == productId);

            if (existingBasketProduct != null)
            {
                existingBasketProduct.BasProCount += quantity;
                product.StockCount -= quantity;
            }
            else
            {
                var newBasketProduct = new BasketProduct
                {
                    BasketId = basketId,
                    Basket = basket,
                    ProductId = productId,
                    Product = product,
                    BasProCount = quantity
                };

                basket.BasketProducts.Add(newBasketProduct);
            }

        }
        product.StockCount -= quantity;
        _dbContext.SaveChanges();
    }
}
