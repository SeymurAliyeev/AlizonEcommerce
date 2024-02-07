using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Business.Services;

public class InvoiceService: IInvoiceServices
{
    private readonly AlizonDbContext _dbContext;
    public InvoiceService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void CreateInvoice(int _userId_, int basketId, int walletId)
    {
        var user = _dbContext.Users
            .Include(u => u.Basket)
            .Include(u => u.Wallets)
            .FirstOrDefault(u => u.Id == _userId_);

        if (user != null)
        {
            var basket = _dbContext.Baskets.FirstOrDefault(b => b.Id == basketId);

            if (basket != null)
            {
                decimal totalCost = basket.BasketProducts.Sum(bp => bp.Product.Price * bp.BasProCount);

                Wallet dbWallet = _dbContext.Wallets.FirstOrDefault(w => w.Id != walletId);
                throw new NotFoundException($"{walletId} is not found");
                var invoice = new Invoice
                {
                    UserId = _userId_,
                    CreateTime = DateTime.Now,
                    InvoiceStatus = "Unpaid",
                    ProductInvoices = new List<ProductInvoice>()
                };
                _dbContext.Invoices.Add(invoice);
                _dbContext.SaveChanges();

                var selectedWallet = user.Wallets.FirstOrDefault(w => w.Id == walletId);

                if (selectedWallet != null && selectedWallet.CardBalance >= totalCost)
                {
                    selectedWallet.CardBalance -= totalCost;

                    var _invoice = new Invoice
                    {
                        UserId = _userId_,
                        CreateTime = DateTime.Now,
                        InvoiceStatus = "Paid",
                        ProductInvoices = new List<ProductInvoice>()
                    };

                    foreach (var basketProduct in basket.BasketProducts)
                    {
                        invoice.ProductInvoices.Add(new ProductInvoice
                        {
                            ProductId = basketProduct.ProductId,
                            InvProCount = basketProduct.BasProCount,
                            InvProPrice = basketProduct.Product.Price
                        });
                    }

                    _dbContext.Invoices.Add(_invoice);
                    _dbContext.SaveChanges();

                    _dbContext.BasketProducts.RemoveRange(basket.BasketProducts);
                    _dbContext.SaveChanges();

                    Console.WriteLine($"Invoice paid successfully. Total cost: {totalCost};   Remaining balance: {selectedWallet.CardBalance};");
                }
                else
                {
                    var __invoice = new Invoice
                    {
                        UserId = _userId_,
                        CreateTime = DateTime.Now,
                        InvoiceStatus = "Unpaid",
                        ProductInvoices = new List<ProductInvoice>()
                    };
                    _dbContext.Invoices.Add(__invoice);
                    _dbContext.SaveChanges();
                    Console.WriteLine($"Insufficient balance. Total cost: {totalCost}. Current balance: {selectedWallet.CardBalance};");
                }
            }
            else
            {
                var invoice1 = new Invoice
                {
                    UserId = _userId_,
                    CreateTime = DateTime.Now,
                    InvoiceStatus = "Canceled",
                    ProductInvoices = new List<ProductInvoice>()
                };
                _dbContext.Invoices.Add(invoice1);
                _dbContext.SaveChanges();
                Console.WriteLine($"Basket is not found");
            }
        }
        else
        {
            var invoice2 = new Invoice
            {
                UserId = _userId_,
                CreateTime = DateTime.Now,
                InvoiceStatus = "Canceled",
                ProductInvoices = new List<ProductInvoice>()
            };
            _dbContext.Invoices.Add(invoice2);
            _dbContext.SaveChanges();
            Console.WriteLine($"User with the ID of {_userId_} is not found.");
        }
    }

    public void ShowAll()
    {
        var invoices = _dbContext.Invoices
            .Include(i => i.User)
            .Include(i => i.ProductInvoices)
            .AsNoTracking()
            .ToList();

        if (invoices.Any())
        {
            Console.WriteLine("All Invoices:");

            foreach (var invoice in invoices)
            {
                Console.WriteLine($"Invoice ID: {invoice.Id}\n");
                Console.WriteLine($"User ID: {invoice.UserId} \n");
                Console.WriteLine($"Purchase Date: {invoice.CreateTime}\n");
                Console.WriteLine($"Invoice Status: {invoice.InvoiceStatus} \n");

                Console.WriteLine("------------------------------");

                foreach (var productInvoice in invoice.ProductInvoices)
                {
                    Console.WriteLine($"Product ID: {productInvoice.ProductId}\n");
                    Console.WriteLine($"Product Count: {productInvoice.InvProCount}\n");
                    Console.WriteLine($"Product Price: {productInvoice.InvProPrice}");
                }

            }
        }
        else
        {
            Console.WriteLine("No invoices found");
        }
    }
}
