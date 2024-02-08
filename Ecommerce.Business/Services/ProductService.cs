using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerce.Business.Services;

public class ProductService : IProductServices
{
    private readonly AlizonDbContext _dbContext;
    public ProductService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async void Create(string name, decimal price, string description, int stockCount, string categoryName, string brandName)
    {

        Product? dbProduct = _dbContext.Products.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        if (dbProduct is not null)
        {
            throw new AlreadyExistException($"{dbProduct.Name} is already exist");
        }

        Category? _category = _dbContext.Categories.FirstOrDefault(c => c.Name.ToLower() == categoryName.ToLower());
        if (_category is null)
        {
            throw new NotFoundException($"{categoryName} is not found");
        }

        Brand? _brand = _dbContext.Brands.FirstOrDefault(b => b.Name.ToLower() == brandName.ToLower());
        if (_brand is null)
        {
            throw new NotFoundException($"{brandName} is not found");
        }

        Product product = new()
        {
            Name = name,
            Price = price,
            Description = description,
            StockCount = stockCount,
            Category = _category,
            Brand = _brand
        };

        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        Console.WriteLine($"Product with the name of {product.Name} has successfully been created!!!");
    }


    public void Deactivate(string name)
    {
        Product? dbProduct = _dbContext.Products.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());

        if (dbProduct is null)
        {
            throw new NotFoundException($"{name} is not found");
        }

        dbProduct.isDelete = true;
        _dbContext.SaveChanges();

        Console.WriteLine($"{dbProduct.Name} has been deactivated!!!");
    }

    public void Delete(string name)
    {
        Product? dbProduct = _dbContext.Products.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());

        if (dbProduct is null)
        {
            throw new NotFoundException($"{name} is not found");
        }

        _dbContext.Products.Remove(dbProduct);
        _dbContext.SaveChanges();

        Console.WriteLine($"{dbProduct.Name} has been deleted!!!");
    }

    public void ShowAll()
    {
        foreach (Product product in _dbContext.Products)
        {
            product.isDelete = false;
            Console.WriteLine($"Product name:  {product.Name};  Price:  {product.Price};  Stock count:  {product.StockCount};  Category Id:  {product.CategoryId};  Product Id: {product.BrandId};  Discount: {product.Discount};");
        }
    }

    public void ShowAllDeactivated()
    {
        foreach (Product product in _dbContext.Products)
        {
            product.isDelete = true;
            Console.WriteLine($"{product.Name};  {product.Price};  {product.StockCount};  {product.Category};  {product.Brand};  {product.Discount};");
        }
    }


    public void Update(string name, decimal newprice, int addcount)
    {
        Product? dbProduct = _dbContext.Products.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());

        if (dbProduct is null)
        {
            throw new NotFoundException($"{name} is not found");
        }

        if (newprice > 0 && addcount >= 0)
        {
            dbProduct.Price = newprice;
            dbProduct.StockCount += addcount;
            _dbContext.SaveChanges();
            Console.WriteLine($"{dbProduct.Name} has successfully been updated");
        }
    }
}
