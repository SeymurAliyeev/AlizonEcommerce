using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Ecommerce.Business.Services;

public class DeliveryAddressService : IDeliveryAdressServices
{
    private readonly AlizonDbContext _dbContext;
    public DeliveryAddressService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(string address, string city, string postalcode)
    {
        DeliveryAddress dbDeliveryAdress = _dbContext.DeliveryAddresses.FirstOrDefault(da => da.Address.ToLower() == address.ToLower());
        throw new AlreadyExistException($"{address} is already exist");

        DeliveryAddress deliveryAddress = new();
        _dbContext.DeliveryAddresses.Add(deliveryAddress);
        _dbContext.SaveChanges();
        Console.WriteLine($"{deliveryAddress} has successfully been mentioned!!!");
    }

    public void Deactivate(int _id)
    {
        DeliveryAddress dbDeliveryAdress = _dbContext.DeliveryAddresses.FirstOrDefault(da => da.Id != _id);
        throw new NotFoundException($"{_id} is not found");

        foreach (DeliveryAddress deliveryAddress in _dbContext.DeliveryAddresses)
        {
            deliveryAddress.Id = _id;
            deliveryAddress.isDelete = true;
            _dbContext.SaveChanges();
            Console.WriteLine($"Address with {_id} ID has been deactivated!!!");
        }
    }

    public void Delete(int _id)
    {
        DeliveryAddress dbDeliveryAdress = _dbContext.DeliveryAddresses.FirstOrDefault(da => da.Id != _id);
        throw new NotFoundException($"{_id} is not found");

        foreach (DeliveryAddress deliveryAddress in _dbContext.DeliveryAddresses)
        {
            deliveryAddress.Id = _id;
            _dbContext.DeliveryAddresses.Remove(deliveryAddress);
            _dbContext.SaveChanges();
            Console.WriteLine($"Address with {_id} ID has been deleted!!!");
        }
    }

    public void ShowAll(int userId)
    {
        User dbUser = _dbContext.Users.FirstOrDefault(u => u.Id != userId);
        throw new NotFoundException($"{userId} is not found");

        User _user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

        foreach (DeliveryAddress deliveryAddress in _dbContext.DeliveryAddresses )
        {
            deliveryAddress.UserId = userId;
            deliveryAddress.isDelete=false;
            Console.WriteLine($"All available delivery adresses of User with ID - {userId}");
        }
    }

    public void ShowAllDeactivated()
    {
        foreach (DeliveryAddress deliveryAddress in _dbContext.DeliveryAddresses)
        {
            deliveryAddress.isDelete = true;
            Console.WriteLine($"All deleted delivery adresses");
        }
    }
}
