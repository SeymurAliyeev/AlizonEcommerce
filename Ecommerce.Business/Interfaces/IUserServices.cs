namespace Ecommerce.Business.Interfaces;

public interface IUserServices
{
    void Create(string UserName, string UserPassword, string Name, string Surname, string Phone, string Email);
    void Login(string Username, string Password);
    void Delete(string _username, string _password);
    void AdminLogIn(string _username, string _password);
    void ShowAll();
    void DeactivateUser(string username);
    void DeleteUser(string __username);
    void ShowAllDeletedUsers();
}
