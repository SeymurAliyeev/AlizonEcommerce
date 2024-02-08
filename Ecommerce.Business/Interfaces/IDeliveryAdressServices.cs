namespace Ecommerce.Business.Interfaces;

public interface IDeliveryAdressServices
{
    void Create(string address,string city,string postalcode, int _userId);
    void DeleteAsync(int _id);
    void Deactivate(string address);
    void ShowAllAsync(int _userId);
    public void ShowAllAddresses();
    void ShowAllDeactivated();
}
