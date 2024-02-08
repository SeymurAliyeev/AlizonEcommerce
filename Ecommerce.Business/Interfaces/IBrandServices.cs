namespace Ecommerce.Business.Interfaces;

public interface IBrandServices
{
    Task CreateAsync(string brandName);
    void Delete(string brandName);
    Task DeactivateAsync(string brandName);
    public void ShowAll();
}
