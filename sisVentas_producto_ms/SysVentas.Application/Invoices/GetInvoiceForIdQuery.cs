using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SysVentas.Application.Categorys.ModelView;
using SysVentas.Application.Clients.ModelView;
using SysVentas.Application.Invoices.ModelView;
using SysVentas.Domain.Contracts;
using SysVentas.Domain.Entities.Invoices;
namespace SysVentas.Application.Invoices
{
    public class GetInvoiceForIdQuery : IRequestHandler<GetInvoiceForIdRequest, GetInvoiceForIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetInvoiceForIdQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<GetInvoiceForIdResponse> Handle(GetInvoiceForIdRequest request, CancellationToken cancellationToken)
        {
            var invoiceMaster = _unitOfWork.InvoicesMasterRepository.FindFirstOrDefault(t => t.Id == request.Id, includeProperties: "Client,Details.Product.Category");
           
            return Task.FromResult(new GetInvoiceForIdResponse(MapperInvoice(invoiceMaster)));
        }

        private InvoiceMasterModelView MapperInvoice(InvoiceMaster invoiceMaster) {
            var invoiceModelView = new InvoiceMasterModelView
            {
                Id = invoiceMaster.Id,
                Status = invoiceMaster.Status,
                Total = invoiceMaster.Total,
                ClientId = invoiceMaster.ClientId,
                DateCancel = invoiceMaster.DateCancel,
                CreatedAt = invoiceMaster.CreatedAt,
                Client = new ClientModelView().ToDTO(invoiceMaster.Client),
                Details = MapperInvoiceDetail(invoiceMaster.Details)
            };
            return invoiceModelView;
        }

        private List<InvoiceDetailModelView> MapperInvoiceDetail(List<InvoiceDetail> invoicesDetails) {
            var invoicesDetailsModelViews = new List<InvoiceDetailModelView>();

            invoicesDetails.ForEach(invoiceDetail =>
            {
                var invoiceDetailModelView = new InvoiceDetailModelView
                {
                    Amount = invoiceDetail.Amount,
                    Id = invoiceDetail.Id,
                    Status = invoiceDetail.Status,
                    Price = invoiceDetail.Price,
                    Total = invoiceDetail.Total,
                    ProductId = invoiceDetail.ProductId,
                    Product = new ProductModelView().ToDTO(invoiceDetail.Product)
                };
                invoicesDetailsModelViews.Add(invoiceDetailModelView);
            });
            return invoicesDetailsModelViews;
        }
    }

    public class GetInvoiceForIdRequest : IRequest<GetInvoiceForIdResponse>
    {
        public long Id { get; set; }
    }
    public class GetInvoiceForIdResponse
    {
        public InvoiceMasterModelView InvoiceMaster { get; set; }
        public GetInvoiceForIdResponse(InvoiceMasterModelView invoiceMasterModelView)
        {
            InvoiceMaster = invoiceMasterModelView;
        }
    }
    public class GetInvoiceForIdValidator : AbstractValidator<GetInvoiceForIdRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetInvoiceForIdValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Id).Must(ExistInvoiceMaster).WithMessage(t => $"Factura de id {t.Id} no encontrado");
            
        }
        private bool ExistInvoiceMaster(long idInvoiceMaster)
        {
            var invoiceMaster = _unitOfWork.InvoicesMasterRepository.FindFirstOrDefault(t => t.Id == idInvoiceMaster);
            return invoiceMaster != null;
        }

    }

   
}
