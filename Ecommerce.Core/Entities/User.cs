using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class User : BaseEntities
{
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
