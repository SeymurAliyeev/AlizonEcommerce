using Ecommerce.Business.Utilities.Helpers;

namespace Ecommerce.Business.Interfaces;

public interface IUserServices
{
    void Create(string UserName, string UserPassword, string Name, string Surname, string Phone, string Email);
    Task<UserAcces> LoginAsync(string Username, string Password);
    void Delete(string _username, string _password);
    Task<bool> AdminLogInAsync(string _username, string _password);
    void ShowAll();
    void DeactivateUser(string username);
    void DeleteUser(string __username);
    void ShowAllDeletedUsers();
}
