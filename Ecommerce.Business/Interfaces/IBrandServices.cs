namespace Ecommerce.Business.Interfaces;

public interface IBrandServices
{
    void Create(string brandName);
    void Delete(string brandName);
    void Deactivate(string brandName);
}
