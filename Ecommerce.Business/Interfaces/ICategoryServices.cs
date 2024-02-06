namespace Ecommerce.Business.Interfaces;

public interface ICategoryServices
{
    void Create(string categoryName);
    void Delete(string categoryName);
    void Deactivate(string categoryName);
}
