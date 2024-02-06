using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;

namespace Ecommerce.Business.Services;

public class BrandService : IBrandServices
{
    private readonly AlizonDbContext _dbContext;
    public BrandService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(string brandName)
    {
        Brand dbBrand = _dbContext.Brands.FirstOrDefault(b => b.Name.ToLower() == brandName.ToLower());
        throw new AlreadyExistException($"{brandName} is already exist");

        Brand brand = new();
        _dbContext.Brands.Add(brand);
        _dbContext.SaveChanges();
        Console.WriteLine($"{brand} has successfully been created!!!");
    }

    public void Deactivate(string brandName)
    {
        Brand dbBrand = _dbContext.Brands.FirstOrDefault(b => b.Name.ToLower() != brandName.ToLower());
        throw new NotFoundException($"{brandName} is not found");

        foreach (Brand brand in _dbContext.Brands)
        {
            brand.Name = brandName;
            brand.isDelete = true;
            _dbContext.SaveChanges();
            Console.WriteLine($"{brandName} has been deactivated!!!");
        }
    }

    public void Delete(string brandName)
    {
        Brand dbBrand = _dbContext.Brands.FirstOrDefault(b => b.Name.ToLower() != brandName.ToLower());
        throw new NotFoundException($"{brandName} is not found");

        foreach (Brand brand in _dbContext.Brands)
        {
            brand.Name = brandName;
            _dbContext.Brands.Remove(brand);
            _dbContext.SaveChanges();
            Console.WriteLine($"{brandName} has been deleted!!!");
        }
    }
}
