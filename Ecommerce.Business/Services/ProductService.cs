using Ecommerce.Business.Interfaces;

namespace Ecommerce.Business.Services;

public class ProductService : IProductServices
{
    public void Create(string name, decimal price, string description, int stockCount, string categoryName, string brandName)
    {
        throw new NotImplementedException();
    }

    public void Deactivate(string name)
    {
        throw new NotImplementedException();
    }

    public void Delete(string name)
    {
        throw new NotImplementedException();
    }

    public void ShowAll()
    {
        throw new NotImplementedException();
    }

    public void ShowAllDeactivated()
    {
        throw new NotImplementedException();
    }

    public void Update(string name)
    {
        throw new NotImplementedException();
    }
}
