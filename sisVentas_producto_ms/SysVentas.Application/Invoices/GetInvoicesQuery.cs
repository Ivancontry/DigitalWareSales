using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SysVentas.Application.Clients.ModelView;
using SysVentas.Application.Invoices.ModelView;
using SysVentas.Domain.Contracts;
using SysVentas.Domain.Entities.Invoices;

namespace SysVentas.Application.Invoices
{
    public class GetInvoicesQuery : IRequestHandler<GetInvoicesRequest, GetInvoicesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetInvoicesQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<GetInvoicesResponse> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
        {
            var invoices = _unitOfWork.InvoicesMasterRepository.FindBy(includeProperties:"Client").ToList();           
            return Task.FromResult(new GetInvoicesResponse(this.MapperInvoice(invoices)));
        }

        private List<InvoiceMasterModelView> MapperInvoice(List<InvoiceMaster> invoicesMaster)
        {
            var invoicesModelView = new List<InvoiceMasterModelView>();
            invoicesMaster.ForEach(invoiceMaster => {
                var invoiceModelView = new InvoiceMasterModelView();
                invoiceModelView.Id = invoiceMaster.Id;
                invoiceModelView.Status = invoiceMaster.Status;
                invoiceModelView.Total = invoiceMaster.Total;
                invoiceModelView.ClientId = invoiceMaster.ClientId;
                invoiceModelView.Client = new ClientModelView().ToDTO(invoiceMaster.Client);
                invoicesModelView.Add(invoiceModelView);

            });
            return invoicesModelView;
        }
    }
    public class GetInvoicesRequest: IRequest<GetInvoicesResponse>
    {
    }
    public class GetInvoicesResponse
    {
        public List<InvoiceMasterModelView> InvoiceMasters { get; set; }
        public GetInvoicesResponse(List<InvoiceMasterModelView> invoices)
        {
            InvoiceMasters = invoices;
        }
    }
}
