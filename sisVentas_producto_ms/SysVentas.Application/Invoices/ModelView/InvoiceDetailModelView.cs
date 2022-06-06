using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVentas.Application.Base;
using SysVentas.Application.Categorys.ModelView;
using SysVentas.Domain.Entities.Invoices;

namespace SysVentas.Application.Invoices.ModelView
{
    public class InvoiceDetailModelView : DTO<long, InvoiceDetail, InvoiceDetailModelView>
    {
        public InvoiceMasterModelView InvoiceMaster { get; set; }
        public long ProductId { get; set; }
        public ProductModelView Product { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public long InvoiceMasterId { get; set; }
        public string Status { get; set; }
    }
}
