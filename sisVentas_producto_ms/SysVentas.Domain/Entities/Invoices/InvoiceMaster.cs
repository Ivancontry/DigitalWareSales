using System;
using System.Collections.Generic;
using SysVentas.Domain.Base;
using SysVentas.Domain.Entities.Clients;
namespace SysVentas.Domain.Entities.Invoices
{
    public class InvoiceMaster : Entity<long>
    {
        public long ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCancel { get; private set; }
        public decimal Total { get; set; }
        public List<InvoiceDetail> Details { get; set; }
        private InvoiceMaster()
        {

        }
        public InvoiceMaster(DateTime date, long clientId)
        {
            Date = date;
            ClientId = clientId;
            Status = StatusView.Get(StatusObject.Approve);
            Details = new List<InvoiceDetail>();
        }
        public void AddDetail(long productId, decimal quantity, decimal price)
        {
            var detail = new InvoiceDetail(this, productId, quantity, price);
            Total += detail.Total;
            Details.Add(detail);
        }
        public void Cancel(DateTime date)
        {
            Status = StatusView.Get(StatusObject.Cancel);
            DateCancel = date;
        }

    }
}
