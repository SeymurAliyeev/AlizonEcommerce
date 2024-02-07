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
                    try
                    {
                        Console.WriteLine("Please, enter admin username:");
                        string _username = Console.ReadLine();
                        Console.WriteLine("Please, enter admin password:");
                        string _password = Console.ReadLine();
                        userService.AdminLogIn(_username, _password);

                        bool looping = true;
                        while (looping)
                        {
                            Console.WriteLine("Choose the option:");
                            Console.WriteLine("1  -  Create Product\n" +
                                              "2  -  Update Product\n" +
                                              "3  -  Deactivate Product\n" +
                                              "4  -  Delete Product\n" +
                                              "5  -  Show All Products\n" +
                                              "6  -  Show All Deactivated Products\n" +
                                              "7  -  Create Discount for Product\n" +
                                              "8  -  Show All Users\n" +
                                              "9  -  Show All Deleted Users\n" +
                                              "10  -  Deactivate User\n" +
                                              "11  -  Delete User\n" +
                                              "12  -  Show All Invoices\n" +
                                              "13  -  Show All Delivery Addresses\n" +
                                              "14  -  Show All Deleted Delivery Addresses\n" +
                                              "0  -  Exit");

                            string? num = Console.ReadLine();
                            int Number;
                            bool IsInt = int.TryParse(num, out Number);
                            if (IsInt)
                            {
                                if (Number >= 0 && Number <= 14)
                                {
                                    switch (Number)
                                    {
                                        case 1:
                                            try
                                            {
                                                Console.WriteLine("Please, enter product name:");
                                                string name = Console.ReadLine();
                                                Console.WriteLine("Please, enter product price:");
                                                decimal price = Convert.ToDecimal(Console.ReadLine());
                                                Console.WriteLine("Please, enter product description:");
                                                string description = Console.ReadLine();
                                                Console.WriteLine("Please, enter product stock count:");
                                                int stockCount = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Please, enter the category name of product:");
                                                string categoryName = Console.ReadLine();
                                                Console.WriteLine("Please, enter the brand name of product:");
                                                string brandName = Console.ReadLine();
                                                productService.Create(name, price, description, stockCount, categoryName, brandName);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                goto case 1;
                                            }
                                            break;

                                        case 2:
                                            try
                                            {
                                                Console.WriteLine("Please, enter product name:");
                                                string name = Console.ReadLine();
                                                Console.WriteLine("Please, enter new product price:");
                                                decimal newprice = Convert.ToDecimal(Console.ReadLine());
                                                Console.WriteLine("Please, enter the count of addition into product stock count:");
                                                int addcount = Convert.ToInt32(Console.ReadLine());
                                                productService.Update(name, newprice, addcount);
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
                                                Console.WriteLine("Please, enter product name:");
                                                string name = Console.ReadLine();
                                                productService.Deactivate(name);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                goto case 3;
                                            }
                                            break;

                                        case 4:
                                            try
                                            {
                                                Console.WriteLine("Please, enter product name:");
                                                string name = Console.ReadLine();
                                                productService.Delete(name);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                goto case 4;
                                            }
                                            break;

                                        case 5:
                                            Console.WriteLine("All Products:");
                                            Console.WriteLine("---------------------------");
                                            productService.ShowAll();
                                            break;

                                        case 6:
                                            Console.WriteLine("All Deactivated Products:");
                                            Console.WriteLine("---------------------------");
                                            productService.ShowAllDeactivated();
                                            break;

                                        case 7:
                                            try
                                            {
                                                Console.WriteLine("Please,enter product name to which you want to apply discount:");
                                                string productName = Console.ReadLine();
                                                Console.WriteLine("Please, enter the percentage of discount you want to apply for:");
                                                decimal discountpercentage = Convert.ToDecimal(Console.ReadLine());
                                                discountService.GetDiscountedPrice(productName, discountpercentage);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                goto case 7;
                                            }
                                            break;

                                        case 8:
                                            Console.WriteLine("All Users:");
                                            Console.WriteLine("---------------------------");
                                            userService.ShowAll();
                                            break;

                                        case 9:
                                            Console.WriteLine("All Deleted Users:");
                                            Console.WriteLine("---------------------------");
                                            userService.ShowAllDeletedUsers();
                                            break;

                                        case 10:
                                            try
                                            {
                                                Console.WriteLine("Please, enter user name:");
                                                string username = Console.ReadLine();
                                                userService.DeactivateUser(username);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                goto case 10;
                                            }
                                            break;

                                        case 11:
                                            try
                                            {
                                                Console.WriteLine("Please, enter user name:");
                                                string __username = Console.ReadLine();
                                                userService.DeleteUser(__username);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                goto case 11;
                                            }
                                            break;

                                        case 12:
                                            Console.WriteLine("All Invoices:");
                                            Console.WriteLine("---------------------------");
                                            invoiceService.ShowAll();
                                            break;

                                        case 13:
                                            Console.WriteLine("All Delivery Addresses:");
                                            Console.WriteLine("---------------------------");
                                            deliveryAddressService.ShowAll();
                                            break;

                                        case 14:
                                            Console.WriteLine("All Deleted Delivery Addresses:");
                                            Console.WriteLine("---------------------------");
                                            deliveryAddressService.ShowAllDeactivated();
                                            break;

                                        default:
                                            looping = false;
                                            break;

                                    }
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
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 1;
                    }
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
                        userService.Create(UserName, UserPassword, Name, Surname, Phone, Email);

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
                        string username = Console.ReadLine();
                        Console.WriteLine("Please, enter your password:");
                        string password = Console.ReadLine();
                        userService.Login(username, password);
                    }
                    catch (Exception ex)
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
