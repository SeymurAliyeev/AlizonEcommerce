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
    public void Create(string UserName, string UserPassword, string Name, string Surname, string Phone, string Email)
    {
        User dbUser = _dbContext.Users.FirstOrDefault(u => u.UserName.ToLower() == UserName.ToLower());
        throw new AlreadyExistException($"{UserName} is already exist");

        User user = new();
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        Console.WriteLine($"{user} has successfully been created!!!");
    }

    public void Delete(string _username, string _password)
    {
        User dbUser = _dbContext.Users.FirstOrDefault(u => u.UserName.ToLower() != _username.ToLower());
        throw new NotFoundException($"{_username} is not found");

        foreach (User user in _dbContext.Users)
        {
            user.UserName = _username;
            user.UserPassword = _password;
            user.isDelete = true;
            Console.WriteLine($"{user} has been deleted!!!");
        }
    }

    public void Login(string _username, string _password)
    {
        User dbUser = _dbContext.Users.FirstOrDefault(u => u.UserName.ToLower() != _username.ToLower());
        throw new NotFoundException($"{_username} is not found");
        if (dbUser != null)
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
}