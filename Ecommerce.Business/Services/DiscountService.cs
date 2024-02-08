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
        Product? dbProduct = _dbContext.Products.FirstOrDefault(p => p.Name.ToLower() == productName.ToLower());

        if (dbProduct is null)
        {
            throw new NotFoundException($"{productName} is not found");
        }

        var discount = _dbContext.Discounts.FirstOrDefault(d => IsDiscountActive(d.StartTime, d.EndTime));

        if (discount != null && discountpercentage > 0)
        {
            decimal discountedPrice = dbProduct.Price - (dbProduct.Price * discountpercentage / 100);
            return discountedPrice;
        }

        return dbProduct.Price;
    }
}

