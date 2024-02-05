namespace Ecommerce.Business.Utilities.Exceptions;

public class AlreadyExistException : Exception
{
    public AlreadyExistException(string message) : base(message) 
    {
    
    }
}