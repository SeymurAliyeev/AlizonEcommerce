using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Utilities.Exceptions;
using Ecommerce.Core.Entities;
using Ecommerce.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Business.Services;

public class ProductInvoiceService : IProductInvoiceServices
{
    private readonly AlizonDbContext _dbContext;
    public ProductInvoiceService(AlizonDbContext dbContext)
    {
        _dbContext = dbContext;
    }

}

