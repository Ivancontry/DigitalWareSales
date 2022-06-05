using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVentas.Products.Domain.Base;
using SysVentas.Products.Domain.Entities.Invoices;

namespace SysVentas.Products.Domain.Services
{
    public interface ICancelInvoiceMasterService
    {
        public DomainValidation CanCancelInvoiceMaster(InvoiceMaster invoiceMaster);
        public void CancelInvoiceMaster(InvoiceMaster invoiceMaster, DateTime dateCancel);

    }

    public class CancelInvoiceMasterService : ICancelInvoiceMasterService
    {
        public DomainValidation CanCancelInvoiceMaster(InvoiceMaster invoiceMaster)
        {
            var validator = new DomainValidation();
            if (invoiceMaster.Status == StatusView.Get(StatusObject.Cancel)) 
            {
                validator.AddFailed("Cancelar Factura", $"La factura de id {invoiceMaster.Id} ya se encuentra Anulada");
            }
            return validator;
        }

        public void CancelInvoiceMaster(InvoiceMaster invoiceMaster, DateTime dateCancel)
        {
            invoiceMaster.Details.ForEach(invoiceDetail =>
            {
                invoiceDetail.Inactive();
                var product = invoiceDetail.Product;
                product.Category.UpdateStockProduct(product.Id, invoiceDetail.Amount);
            });
            invoiceMaster.Cancel(dateCancel);
        }
    }
}
