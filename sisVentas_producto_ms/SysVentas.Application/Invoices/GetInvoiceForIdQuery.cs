using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SysVentas.Application.Base;
using SysVentas.Application.Categorys.ModelView;
using SysVentas.Application.Clients.ModelView;
using SysVentas.Application.Invoices.ModelView;
using SysVentas.Domain.Contracts;
using SysVentas.Domain.Entities.Invoices;
using SysVentas.Domain.Services;
namespace SysVentas.Application.Invoices
{
    public class GetInvoiceForIdQuery : IRequestHandler<GetInvoiceForIdRequest, GetInvoiceForIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<GetInvoiceForIdRequest> _validator;
        public GetInvoiceForIdQuery(IUnitOfWork unitOfWork, IValidator<GetInvoiceForIdRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public Task<GetInvoiceForIdResponse> Handle(GetInvoiceForIdRequest request, CancellationToken cancellationToken)
        {
            var invoiceMaster = _unitOfWork.InvoicesMasterRepository.FindFirstOrDefault(t => t.Id == request.Id, includeProperties: "Client,Details.Product.Category");
           
            return Task.FromResult(new GetInvoiceForIdResponse(this.MapperInvoice(invoiceMaster)));
        }

        private InvoiceMasterModelView MapperInvoice(InvoiceMaster invoiceMaster) {
            var invoiceModelView = new InvoiceMasterModelView();
            invoiceModelView.Id = invoiceMaster.Id;
            invoiceModelView.Status = invoiceMaster.Status;
            invoiceModelView.Total = invoiceMaster.Total;
            invoiceModelView.ClientId = invoiceMaster.ClientId;
            invoiceModelView.Client = new ClientModelView().ToDTO(invoiceMaster.Client);
            invoiceModelView.Details = this.MapperInvoiceDetail(invoiceMaster.Details);
            return invoiceModelView;
        }

        private List<InvoiceDetailModelView> MapperInvoiceDetail(List<InvoiceDetail> invoicesDetails) {
            var invoicesDetailsModelViews = new List<InvoiceDetailModelView>();

            invoicesDetails.ForEach(invoiceDetail =>
            {
                var invoiceDetailModelView = new InvoiceDetailModelView();
                invoiceDetailModelView.Amount = invoiceDetail.Amount;
                invoiceDetailModelView.Id = invoiceDetail.Id;
                invoiceDetailModelView.Status = invoiceDetail.Status;
                invoiceDetailModelView.Price = invoiceDetail.Price;
                invoiceDetailModelView.Total = invoiceDetail.Total;
                invoiceDetailModelView.ProductId = invoiceDetail.ProductId;
                invoiceDetailModelView.Product = new ProductModelView().ToDTO(invoiceDetail.Product);
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
        private InvoiceMaster _invoiceMaster;
        public GetInvoiceForIdValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Id).Must(ExistInvoiceMaster).WithMessage(t => $"Factura de id {t.Id} no encontrado");
            
        }
        public bool ExistInvoiceMaster(long idInvoiceMaster)
        {
            _invoiceMaster = _unitOfWork.InvoicesMasterRepository.FindFirstOrDefault(t => t.Id == idInvoiceMaster && t.Status != "AN");
            return _invoiceMaster != null;
        }

    }

   
}
