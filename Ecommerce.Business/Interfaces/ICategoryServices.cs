namespace Ecommerce.Business.Interfaces;

public interface ICategoryServices
{
    Task CreateAsync(string categoryName);
    Task DeleteAsync(string categoryName);
    Task DeactivateAsync(string categoryName);
    void ShowAll();
}
