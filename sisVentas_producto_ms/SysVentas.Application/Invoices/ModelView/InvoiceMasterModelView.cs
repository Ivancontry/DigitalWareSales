using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVentas.Application.Base;
using SysVentas.Application.Clients.ModelView;
using SysVentas.Domain.Entities.Invoices;

namespace SysVentas.Application.Invoices.ModelView
{
    public class InvoiceMasterModelView : DTO<long, InvoiceMaster, InvoiceMasterModelView>
    {
        public long ClientId { get; set; }
        public ClientModelView Client { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCancel { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public List<InvoiceDetailModelView> Details { get; set; }
    }
}
