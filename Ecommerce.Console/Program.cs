using Ecommerce.Business.Services;
using Ecommerce.Business.Utilities.Helpers;
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
                       
                        bool adminAccess = await userService.AdminLogInAsync(_username, _password);

                        while (adminAccess)
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
                                            adminAccess = false;
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
                       
                        UserAcces userAccess = await userService.LoginAsync(username, password);
                        bool keeping = userAccess.IsUserAccess;
                       
                        while (keeping)
                        {
                            Console.WriteLine("Choose the option:");
                            Console.WriteLine("1  -  Add Delivery Address\n" +
                                              "2  -  Delete Delivery Address\n" +
                                              "3  -  Add Wallet\n" +
                                              "4  -  Update wallet\n" +
                                              "5  -  Delete Wallet\n" +
                                              "6  -  Take Basket\n" +
                                              "7  -  Show All Products\n" +
                                              "8  -  Add Products into Basket\n" +
                                              "9  -  Buy Selected Products\n" +
                                              "10  -  Show All Wallets\n" +
                                              "0  -  Exit");

                            string? numero = Console.ReadLine();
                            int Numero;
                            bool EInt = int.TryParse(numero, out Numero);
                            if (EInt)
                            {
                                if (Numero >= 0 && Numero <= 14)
                                {
                                    switch (Numero)
                                    {
                                        case 1:
                                            try
                                            {
                                                Console.WriteLine("Please, insert your address:");
                                                string address = Console.ReadLine();
                                                Console.WriteLine("Please, insert name of city where aforementioned address locates:");
                                                string city = Console.ReadLine();
                                                Console.WriteLine("Please, insert the postal code of the nearest post office:");
                                                string postalcode = Console.ReadLine();
                                                
                                                deliveryAddressService.Create(address, city, postalcode);
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
                                                Console.WriteLine("Please, insert the Id of delivery address that you want to delete:");
                                                int _id = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Please, insert your User Id:");
                                                int __userId = Convert.ToInt32(Console.ReadLine());
                                                deliveryAddressService.Deactivate(_id, __userId);
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
                                                Console.WriteLine("Please, enter Card Name you want to add:");
                                                string cardName = Console.ReadLine();
                                                Console.WriteLine("Please, enter Card Number:");
                                                string cardNumber = Console.ReadLine();
                                                Console.WriteLine("Please, enter Card Balance:");
                                                decimal cardBalance = Convert.ToDecimal(Console.ReadLine());
                                                int uuserId = userAccess.UserId;
                                                walletService.CreateAsync(cardName, cardNumber, cardBalance, uuserId);
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
                                                Console.WriteLine("Please, enter Card Number:");
                                                string cardNumber = Console.ReadLine();
                                                Console.WriteLine("Please, enter your User Id:");
                                                int userId_ = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Please, enter the amount you want to add into your card:");
                                                decimal amount = Convert.ToDecimal(Console.ReadLine());
                                                walletService.Update(cardNumber, userId_, amount);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                goto case 4;
                                            }
                                            break;

                                        case 5:
                                            try
                                            {
                                                Console.WriteLine("Please, enter Card Number:");
                                                string cardNumber = Console.ReadLine();
                                                Console.WriteLine("Please, enter your User Id:");
                                                int userid = Convert.ToInt32(Console.ReadLine());
                                                walletService.Delete(cardNumber, userid);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                goto case 5;
                                            }
                                            break;

                                        case 6:
                                            try
                                            {
                                                Console.WriteLine("Please, take your basket in order to add the products into your basket");
                                                Console.WriteLine("Please, enter your Id");
                                                int _userId = Convert.ToInt32(Console.ReadLine());
                                                basketService.Create(_userId);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                goto case 6;
                                            }
                                            break;

                                        case 7:
                                            Console.WriteLine("All products:");
                                            Console.WriteLine("----------------------------------------------------------------------");
                                            productService.ShowAll();
                                            break;

                                        case 8:
                                            try
                                            {
                                                Console.WriteLine("Look at the all products and add into your basket whichever you want to buy:");
                                                productService.ShowAll();
                                                Console.WriteLine("Please, enter your Basket Id");
                                                int basketId = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Please, enter Product Ids which ones you want to buy:");
                                                int productId = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Please, enter the quantity of the selected product");
                                                int quantity = Convert.ToInt32(Console.ReadLine());
                                                basketProductService.AddProductToBasket(basketId, productId, quantity);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                goto case 8;
                                            }
                                            break;

                                        case 9:
                                            try
                                            {
                                                Console.WriteLine("Welcome to the payment session");
                                                Console.WriteLine("Please, enter your User Id");
                                                int _userId_ = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Please, enter your Basket Id");
                                                int basketId = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Please, enter your Wallet Id you want to pay with");
                                                int walletId = Convert.ToInt32(Console.ReadLine());
                                                invoiceService.CreateInvoice(_userId_, basketId, walletId);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                goto case 9;
                                            }
                                            break;

                                        case 10:
                                            Console.WriteLine("Please, enter your User Id");
                                            int userId = Convert.ToInt32(Console.ReadLine());
                                            walletService.ShowAllWallets(userId);
                                            Console.WriteLine("All Wallets");
                                            Console.WriteLine("----------------------------------------");
                                            break;

                                        default:
                                            keeping = false;
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
