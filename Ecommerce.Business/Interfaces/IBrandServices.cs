namespace Ecommerce.Business.Interfaces;

public interface IBrandServices
{
    void CreateAsync(string brandName);
    void DeleteAsync(string brandName);
    void DeactivateAsync(string brandName);
    public void ShowAll();
}
