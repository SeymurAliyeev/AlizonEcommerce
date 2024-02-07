using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;

namespace Ecommerce.Business.Services;


public class UserService : IUserServices
{
    private readonly AlizonDbContext _dbContext;
    public UserService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(string username, string userpassword, string name, string surname, string phone, string email)
    {
        User dbUser = _dbContext.Users.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());
        if (dbUser is not null)
            throw new AlreadyExistException($"{dbUser.UserName} is already exist");

        User user = new()
        {
            UserName = username,
            UserPassword = userpassword,
            Name = name,
            Surname = surname,
            Phone = phone,
            Email = email
        };
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        Console.WriteLine($"{user}, you have successfully registered!!!");
    }

    public void Delete(string _username, string _password)
    {
        User dbUser = _dbContext.Users.FirstOrDefault(u => u.UserName.ToLower() != _username.ToLower());
        if (dbUser is null)
            throw new NotFoundException($"{dbUser.UserName} is not found");

        foreach (User user in _dbContext.Users)
        {
            user.UserName = _username;
            user.UserPassword = _password;
            user.isDelete = true;
            _dbContext.SaveChanges();
            Console.WriteLine($"{user} has been deleted!!!");
        }
    }

    public void Login(string username, string password)
    {
        User dbUser = _dbContext.Users.FirstOrDefault(u => u.UserName.ToLower() != username.ToLower());
        if (dbUser is null)
            throw new NotFoundException($"{dbUser.UserName} is not found");

        if (dbUser != null)
        {
            foreach (User user in _dbContext.Users)
            {
                user.UserName = username;
                user.UserPassword = password;
                Console.WriteLine("Welcome to Alizon Express");
            }
        }
        else Console.WriteLine("Invalid Username or Password");
    }

    public void AdminLogIn(string _username, string _password)
    {
        User dbUser = _dbContext.Users.FirstOrDefault(u => u.UserName.ToLower() != _username.ToLower());
        if (dbUser is null)
            throw new NotFoundException($"Admin with this {dbUser.UserName} is not found");

        if (dbUser is not null && _dbContext is not null)
        {
            foreach (User user in _dbContext.Users)
            {
                user.UserName = _username;
                user.UserPassword = _password;
                Console.WriteLine("Welcome to Alizon Express");
            }
        }
        else Console.WriteLine("Invalid Username or Password");
    }

    public void ShowAll()
    {
        foreach (User user in _dbContext.Users)
        {
            user.isDelete = false;
            Console.WriteLine($"All Users:\n" +
                               $"{user.Name};  {user.Surname};  {user.Phone};  {user.Email};  {user.CreateTime};");
        }
    }

    public void DeactivateUser(string username)
    {
        User dbUser = _dbContext.Users.FirstOrDefault(u => u.UserName.ToLower() != username.ToLower());
        if (dbUser is null)
            throw new NotFoundException($"{dbUser.UserName} is not found");

        foreach (User user in _dbContext.Users)
        {
            user.UserName = username;
            user.isDelete = true;
            _dbContext.SaveChanges();
            Console.WriteLine($"{user} has been deactivated!!!");
        }
    }

    public void DeleteUser (string __username)
    {
        User dbUser = _dbContext.Users.FirstOrDefault(u => u.UserName.ToLower() != __username.ToLower());
        if (dbUser is null)
            throw new NotFoundException($"{dbUser.UserName} is not found");

        foreach (User user in _dbContext.Users)
        {
            user.UserName = __username;
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            Console.WriteLine($"{user} has been deleted!!!");
        }
    }

    public void ShowAllDeletedUsers()
    {
        foreach (User user in _dbContext.Users)
        {
            user.isDelete = true;
            Console.WriteLine($"All Users:\n" +
                               $"{user.Name};  {user.Surname};  {user.Phone};  {user.Email};  {user.CreateTime}; {user.ModifiedTime};");
        }
    }
}