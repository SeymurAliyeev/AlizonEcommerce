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

    public void Deactivate(string address)
    {
        DeliveryAddress? dbDeliveryAdress = _dbContext.DeliveryAddresses.FirstOrDefault(da => da.Address != address);
        if(dbDeliveryAdress is null)
        throw new NotFoundException($"{dbDeliveryAdress.Address} is not found");
        if (dbDeliveryAdress is not null)
        {
            foreach (DeliveryAddress deliveryAddress in _dbContext.DeliveryAddresses)
            {
                deliveryAddress.Address = address;
                _dbContext.DeliveryAddresses.Remove(deliveryAddress);
                _dbContext.SaveChanges();
                Console.WriteLine($"Address with {address} ID has been deleted!!!");
            }
        }
    }

    public async void DeleteAsync(int _id)
    {
        DeliveryAddress? dbDeliveryAddress = _dbContext.DeliveryAddresses.FirstOrDefault(da => da.Id == _id);

        if (dbDeliveryAddress == null)
        {
            throw new NotFoundException($"{_id} is not found");
        }

        _dbContext.DeliveryAddresses.Remove(dbDeliveryAddress);
        await _dbContext.SaveChangesAsync();

        Console.WriteLine($"Address with the ID of {_id} has been deleted!!!");
    }

    public async void ShowAllAsync(int _userId)
    {

        foreach (DeliveryAddress deliveryAddress in _dbContext.DeliveryAddresses )
        {
            deliveryAddress.UserId=_userId;
            deliveryAddress.isDelete=false;
            await _dbContext.SaveChangesAsync();
            Console.WriteLine($"{deliveryAddress.Id};  {deliveryAddress.Address};  {deliveryAddress.City};  {deliveryAddress.PostalCode};{deliveryAddress.UserId}; ");
        }
    }

    public void ShowAllAddresses()
    {

        foreach (DeliveryAddress deliveryAddress in _dbContext.DeliveryAddresses)
        {
            deliveryAddress.isDelete = false;
            Console.WriteLine($"{deliveryAddress.Id};  {deliveryAddress.Address};  {deliveryAddress.City};  {deliveryAddress.PostalCode}; {deliveryAddress.UserId};");
        }
    }

    public void ShowAllDeactivated()
    {
        foreach (DeliveryAddress deliveryAddress in _dbContext.DeliveryAddresses)
        {
            deliveryAddress.isDelete = true;
            Console.WriteLine( $"{deliveryAddress.User};  {deliveryAddress.Address};  {deliveryAddress.City};  {deliveryAddress.PostalCode};");
        }
    }
}
