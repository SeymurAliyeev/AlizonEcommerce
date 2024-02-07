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
    public async void CreateAsync(string brandName)
    {
        Brand? dbBrand = _dbContext.Brands.FirstOrDefault(b => b.Name.ToLower() == brandName.ToLower());
        if (dbBrand is not null) throw new AlreadyExistException($"{brandName} is already exist");

        Brand brand = new()
        {
            Name = brandName
        };
        await _dbContext.Brands.AddAsync(brand);
        await _dbContext.SaveChangesAsync();
        Console.WriteLine($"{brand} has successfully been created!!!");
    }

    public async void DeactivateAsync(string brandName)
    {
        Brand? dbBrand = _dbContext.Brands.FirstOrDefault(b => b.Name.ToLower() != brandName.ToLower());
        if (dbBrand is null) throw new NotFoundException($"{brandName} is not found");

        foreach (Brand brand in _dbContext.Brands)
        {
            brand.Name = brandName;
            brand.isDelete = true;
            await _dbContext.SaveChangesAsync();
            Console.WriteLine($"{brandName} has been deactivated!!!");
        }
    }

    public async void DeleteAsync(string brandName)
    {
        Brand dbBrand = _dbContext.Brands.FirstOrDefault(b => b.Name.ToLower() != brandName.ToLower());
        if (dbBrand is null) throw new NotFoundException($"{brandName} is not found");

        foreach (Brand brand in _dbContext.Brands)
        {
            brand.Name = brandName;
            _dbContext.Brands.Remove(brand);
            await _dbContext.SaveChangesAsync();
            Console.WriteLine($"{brandName} has been deleted!!!");
        }
    }

    public void ShowAll()
    {
        foreach (Brand brand in _dbContext.Brands)
        {
            brand.isDelete = false;
            Console.WriteLine($"All Brands:\n" +
                               $"{brand.Name};");
        }
    }
}
