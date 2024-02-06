namespace Ecommerce.Business.Interfaces;

public interface IUserServices
{
    void Create(string UserName, string UserPassword, string Name, string Surname, string Phone, string Email);
    void Login(string Username, string Password);
    void Delete(string _username, string _password);
    public void AdminLogIn(string _username, string _password);
}
