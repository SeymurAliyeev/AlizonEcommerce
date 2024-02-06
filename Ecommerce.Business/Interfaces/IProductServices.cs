namespace Ecommerce.Business.Interfaces;

public interface IProductServices
{
    void Create(string name, decimal price,string description,int stockCount,string categoryName,string brandName);
    void Delete(string name);
    void Deactivate(string name);
    void Update(string name, decimal newprice,int newstockcount);
    void ShowAll();
    void ShowAllDeactivated();
}
