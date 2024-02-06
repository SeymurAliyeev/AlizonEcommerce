using Ecommerce.Business.Services;
using Ecommerce.DataAccess.Contexts;
using Microsoft.IdentityModel.Tokens;

Console.WriteLine("Alizon Ecommerce Project starts:");

var dbContext = new AlizonDbContext();

var walletService = new WalletService(dbContext);
var userService = new UserService(dbContext);
var productService = new ProductService(dbContext);
var productInvoiceService = new ProductInvoiceService(dbContext);
var invoiceService = new InvoiceService(dbContext);
var discountService = new DiscountService(dbContext);
var deliveryAddressService = new DeliveryAddressService(dbContext);
var categoryService = new CategoryService(dbContext);
var brandService = new BrandService(dbContext);
var basketService = new BasketService(dbContext);
var basketProductService = new BasketProductService(dbContext);


bool keeplooping = true;
while (keeplooping)
{
    Console.WriteLine("Choose the option:");
    Console.WriteLine("1  -  Admin\n" +
                      "2  -  Register\n" +
                      "3  -  Log in\n" +
                      "4  -  Visit as guestuser\n" +
                      "0  -  Exit");

    string? option = Console.ReadLine();
    int OptionNumber;
    bool isInt = int.TryParse(option, out OptionNumber);
    if (isInt)
    {
        if (OptionNumber >= 0 && OptionNumber <= 4)
            switch (OptionNumber)
            {
                case 1:
                    break;

                case 2:
                    try
                    {
                        Console.WriteLine("Welcome to the registration");
                        Console.WriteLine("Please, insert username:");
                        string UserName = Console.ReadLine();
                        Console.WriteLine("Please, insert password:");
                        string UserPassword = Console.ReadLine();
                        Console.WriteLine("Please, insert your Name:");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Please, insert your Surname:");
                        string Surname = Console.ReadLine();
                        Console.WriteLine("Please, insert your Phone Number:");
                        string Phone = Console.ReadLine();
                        Console.WriteLine("Please, insert your email address:");
                        string Email = Console.ReadLine();
                        userService.Create(UserName,UserPassword, Name, Surname, Phone, Email);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 2;
                    }

                    break;

                case 3:
                    try
                    {
                        Console.WriteLine("Please, enter your username:");
                        string _username = Console.ReadLine();
                        Console.WriteLine("Please, enter your password:");
                        string _password = Console.ReadLine();
                        userService.Login(_username, _password);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 3;
                    }
                    break;

                case 4:
                    try
                    {
                        Console.WriteLine("All products:");
                        Console.WriteLine("----------------------------------------------------------------------");
                        productService.ShowAll();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 4;
                    }
                    break;

                default:
                    keeplooping = false;
                    break;
            }
        else
        {
            Console.WriteLine("Please, choose the one of available option numbers!");
        }
    }
    else
    {
        Console.WriteLine("Please, enter correct format!");
    }
}
