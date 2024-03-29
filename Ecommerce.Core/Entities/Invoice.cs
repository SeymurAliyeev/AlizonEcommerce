﻿using Ecommerce.Core.Abstract;

namespace Ecommerce.Core.Entities;

public class Invoice:BaseEntities
{
    public string InvoiceStatus { get; set; }
    public decimal TotalPrice { get; set; }
    public User User { get; set; } = null!;
    public int UserId { get; set; }
    public Wallet Wallet { get; set; } = null!;
    public int WalletId { get; set; }
    public ICollection<ProductInvoice> ProductInvoices { get; set; } = null!;

    public enum invoiceStatus
    {
        Paid,
        Unpaid,
        Canceled
    }
}
