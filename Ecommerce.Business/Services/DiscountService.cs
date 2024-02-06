using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Business.Services;

public class DiscountService : IDiscountServices
{
    private readonly AlizonDbContext _dbContext;
    public DiscountService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    private bool IsDiscountActive(DateTime startTime, DateTime endTime)
    {
        DateTime currentTime = DateTime.Now;

        return currentTime >= startTime && currentTime <= endTime;
    }
    public decimal GetDiscountedPrice(string productName, decimal discountpercentage)
    {
        Product dbProduct = _dbContext.Products.FirstOrDefault(p => p.Name.ToLower() != productName.ToLower());
        throw new NotFoundException($"{productName} is not found");

        var product = _dbContext.Products.FirstOrDefault(p => p.Name == productName);

        if (product != null && discountpercentage > 0)
        {
            var _discountpercentage = _dbContext.Discounts.FirstOrDefault(d => IsDiscountActive(d.StartTime, d.EndTime));

            if (discountpercentage != null)
            {
                return product.Price = product.Price - (product.Price * discountpercentage/100);
            }
        }
        return product.Price;
    }
}

