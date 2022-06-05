using SysVentas.Domain.Base;
using SysVentas.Domain.Entities.Categorys;
namespace SysVentas.Domain.Entities.Invoices
{
    public class InvoiceDetail
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public InvoiceMaster InvoiceMaster { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public long InvoiceMasterId { get; set; }

        public InvoiceDetail()
        {

        }

        public InvoiceDetail(InvoiceMaster invoiceMaster, long productId, decimal quantity, decimal price)
        {
            InvoiceMaster = invoiceMaster;
            ProductId = productId;
            Amount = quantity;
            Price = price;
            Total = Amount * price;
            Status = Status = StatusView.Get(StatusObject.Active);
        }

        public void Inactive()
        {
            Status = StatusView.Get(StatusObject.Inactive);
        }
    }
}
