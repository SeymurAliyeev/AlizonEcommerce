using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Business.Services;

public class ProductService : IProductServices
{
    private readonly AlizonDbContext _dbContext;
    public ProductService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(string name, decimal price, string description, int stockCount, string categoryName, string brandName)
    {
        Product dbProduct = _dbContext.Products.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        throw new AlreadyExistException($"{name} is already exist");

        Product product = new();
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
        Console.WriteLine($"{product} has successfully been created!!!");
    }

    public void Deactivate(string name)
    {
        Product dbProduct = _dbContext.Products.FirstOrDefault(p => p.Name.ToLower() != name.ToLower());
        throw new NotFoundException($"{name} is not found");

        foreach (Product product in _dbContext.Products)
        {
            product.Name = name;
            product.isDelete = true;
            _dbContext.SaveChanges();
            Console.WriteLine($"{product} has been deactivated!!!");
        }
    }

    public void Delete(string name)
    {
        Product dbProduct = _dbContext.Products.FirstOrDefault(p => p.Name.ToLower() != name.ToLower());
        throw new NotFoundException($"{name} is not found");

        foreach (Product product in _dbContext.Products)
        {
            product.Name = name;
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            Console.WriteLine($"{product} has been deleted!!!");
        }
    }

    public void ShowAll()
    {
        foreach (Product product in _dbContext.Products)
        {
            product.isDelete = false;
            Console.WriteLine("All Products");
        }
    }

    public void ShowAllDeactivated()
    {
        foreach (Product product in _dbContext.Products)
        {
            product.isDelete = true;
            Console.WriteLine("All Deactivated Products");
        }
    }


    public void Update(string name, decimal newprice, int newstockcount)
    {
        Product dbProduct = _dbContext.Products.FirstOrDefault(p => p.Name.ToLower() != name.ToLower());
        throw new NotFoundException($"{name} is not found");

        var product = _dbContext.Products.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());

        if (newprice>0 && newstockcount>=0)
        {
            product.Price = newprice;
            product.StockCount += newstockcount;
            _dbContext.SaveChanges();
            Console.WriteLine($"Product has successfully been updated");
        }
    }
}
