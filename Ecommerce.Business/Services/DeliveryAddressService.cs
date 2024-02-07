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
    public async void Create(string address, string city, string postalcode, int _userId)
    {
        DeliveryAddress dbDeliveryAdress = _dbContext.DeliveryAddresses.FirstOrDefault(da => da.Address.ToLower() == address.ToLower());
        if (dbDeliveryAdress is not null)
            throw new AlreadyExistException($"{dbDeliveryAdress.Address} is already exist");

        DeliveryAddress deliveryAddress = new()
        {
            Address = address,
            City = city,
            PostalCode = postalcode,
            UserId = _userId
             
        };
        _dbContext.DeliveryAddresses.Add(deliveryAddress);
        _dbContext.SaveChanges();
        Console.WriteLine($"{deliveryAddress} has successfully been mentioned!!!");
    }

    public void Deactivate(int _id, int __userId)
    {
        DeliveryAddress dbDeliveryAdress = _dbContext.DeliveryAddresses.FirstOrDefault(da => da.Id != _id);
        if(dbDeliveryAdress is null)
        throw new NotFoundException($"{dbDeliveryAdress.Id} is not found");

        foreach (DeliveryAddress deliveryAddress in _dbContext.DeliveryAddresses)
        {
            deliveryAddress.Id = _id;
            deliveryAddress.UserId = __userId;
            deliveryAddress.isDelete = true;
            _dbContext.SaveChanges();
            Console.WriteLine($"Address with {_id} ID has been deleted!!!");
        }
    }

    public void Delete(int _id)
    {
        DeliveryAddress dbDeliveryAdress = _dbContext.DeliveryAddresses.FirstOrDefault(da => da.Id != _id);
        if(dbDeliveryAdress is null)
        throw new NotFoundException($"{dbDeliveryAdress.Id} is not found");

        foreach (DeliveryAddress deliveryAddress in _dbContext.DeliveryAddresses)
        {
            deliveryAddress.Id = _id;
            _dbContext.DeliveryAddresses.Remove(deliveryAddress);
            _dbContext.SaveChanges();
            Console.WriteLine($"Address with {_id} ID has been deleted!!!");
        }
    }

    public void ShowAll()
    {

        foreach (DeliveryAddress deliveryAddress in _dbContext.DeliveryAddresses )
        {
            deliveryAddress.isDelete=false;
            Console.WriteLine($"All Delivery Addresses:\n" +
                               $"{deliveryAddress.User};  {deliveryAddress.Address};  {deliveryAddress.City};  {deliveryAddress.PostalCode};");
        }
    }

    public void ShowAllDeactivated()
    {
        foreach (DeliveryAddress deliveryAddress in _dbContext.DeliveryAddresses)
        {
            deliveryAddress.isDelete = true;
            Console.WriteLine($"All Deleted Delivery Addresses:\n" +
                               $"{deliveryAddress.User};  {deliveryAddress.Address};  {deliveryAddress.City};  {deliveryAddress.PostalCode};");
        }
    }
}
