namespace Ecommerce.Business.Interfaces;

public interface ICategoryServices
{
    void CreateAsync(string categoryName);
    void DeleteAsync(string categoryName);
    void DeactivateAsync(string categoryName);
    void ShowAll();
}
