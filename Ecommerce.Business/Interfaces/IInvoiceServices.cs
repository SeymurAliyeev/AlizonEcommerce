namespace Ecommerce.Business.Interfaces;

public interface IInvoiceServices
{
    void CreateInvoice(int _userId_, int basketId, int walletId);
    void ShowAll();
}
