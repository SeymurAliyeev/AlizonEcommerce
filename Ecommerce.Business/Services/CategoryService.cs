using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;

namespace Ecommerce.Business.Services;

public class CategoryService : ICategoryServices
{
    private readonly AlizonDbContext _dbContext;
    public CategoryService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateAsync(string categoryName)
    {
        Category? dbCategory = _dbContext.Categories.FirstOrDefault(c => c.Name.ToLower() == categoryName.ToLower());
        if(dbCategory is not null )  throw new AlreadyExistException($"{categoryName} is already exist");

        Category category = new()
        {
            Name = categoryName
        };
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        Console.WriteLine($"{category.Name} has successfully been created!!!");
    }

    public async Task DeactivateAsync(string categoryName)
    {
        Category? dbCategory = _dbContext.Categories.FirstOrDefault(c => c.Name.ToLower() != categoryName.ToLower());
        if(dbCategory is null ) throw new NotFoundException($"{categoryName} is not found");

        foreach (Category category in _dbContext.Categories)
        {
            category.Name = categoryName;
            category.isDelete = true;
            await _dbContext.SaveChangesAsync();
            Console.WriteLine($"{categoryName} has been deactivated!!!");
        }
    }

    public async Task DeleteAsync(string categoryName)
    {
        Category? dbCategory = _dbContext.Categories.FirstOrDefault(c => c.Name.ToLower() == categoryName.ToLower());

        if (dbCategory == null)
        {
            throw new NotFoundException($"{categoryName} is not found");
        }

        _dbContext.Categories.Remove(dbCategory);
        await _dbContext.SaveChangesAsync();

        Console.WriteLine($"{categoryName} has been deleted!!!");
    }

    public void ShowAll()
    {
        foreach (Category category in _dbContext.Categories)
        {
            category.isDelete = false;
            Console.WriteLine($"{category.Name};");
        }
    }
}
