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
    public async Task CreateAsync(string brandName)
    {
        Brand? dbBrand = _dbContext.Brands.FirstOrDefault(b => b.Name.ToLower() == brandName.ToLower());
        if (dbBrand is not null) throw new AlreadyExistException($"{brandName} is already exist");

        Brand brand = new()
        {
            Name = brandName
        };
        await _dbContext.Brands.AddAsync(brand);
        await _dbContext.SaveChangesAsync();
        Console.WriteLine($"{dbBrand.Name} has successfully been created!!!");
    }

    public async Task DeactivateAsync(string brandName)
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

    public void Delete(string brandName)
    {
        Brand? dbBrand = _dbContext.Brands.FirstOrDefault(b => b.Name.ToLower() == brandName.ToLower());
        if (dbBrand is null) throw new NotFoundException($"{brandName} is not found");
        
        _dbContext.Brands.Remove(dbBrand);
        _dbContext.SaveChanges();

        Console.WriteLine($"{dbBrand.Name} has been deleted");
        
      
    }

    public void ShowAll()
    {
        foreach (Brand brand in _dbContext.Brands)
        {
            brand.isDelete = false;
            Console.WriteLine($"{brand.Name};");
        }
    }
}
