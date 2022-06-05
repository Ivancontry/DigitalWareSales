using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SysVentas.Application.Invoices.ModelView;
using SysVentas.Domain.Contracts;

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
            var invoiceModelView = new InvoiceMasterModelView();
            var invoicesModelViews = invoiceModelView.ToListDTO(invoices);
            return Task.FromResult(new GetInvoicesResponse(invoicesModelViews));
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
