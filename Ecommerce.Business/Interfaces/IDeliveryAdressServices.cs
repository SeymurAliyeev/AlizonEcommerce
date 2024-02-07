﻿namespace Ecommerce.Business.Interfaces;

public interface IDeliveryAdressServices
{
    void Create(string address,string city,string postalcode, int _userId);
    void Delete(int _id);
    void Deactivate(int _id, int __userId);
    void ShowAll();
    void ShowAllDeactivated();
}
