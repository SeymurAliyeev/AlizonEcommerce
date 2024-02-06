﻿namespace Ecommerce.Business.Interfaces;

public interface IDeliveryAdressServices
{
    void Create(string address,string city,string postalcode);
    void Delete(int _id);
    void Deactivate(int _id);
    void ShowAll(int userId);
    void ShowAllDeactivated();
}