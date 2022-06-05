﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SysVentas.Products.Application.Base;
using SysVentas.Products.Domain.Base;
using SysVentas.Products.Domain.Entities.Categorys;
using SysVentas.Products.Domain.Entities.Invoices;
using SysVentas.Products.Domain.Services;

namespace SysVentas.Products.Application.Invoices
{
    public class CancelInvoiceCommand : IRequestHandler<CancelInvoiceRequest, CancelInvoiceResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CancelInvoiceRequest> _validator;
        private readonly ICancelInvoiceMasterService _cancelInvoiceMasterService;
        public CancelInvoiceCommand(ICancelInvoiceMasterService cancelInvoiceMasterService,IUnitOfWork unitOfWork, IValidator<CancelInvoiceRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _cancelInvoiceMasterService = cancelInvoiceMasterService;
        }

        public Task<CancelInvoiceResponse> Handle(CancelInvoiceRequest request, CancellationToken cancellationToken)
        {
            var invoiceMaster = _unitOfWork.InvoicesMasterRepository.FindFirstOrDefault(t => t.Id == request.Id, includeProperties: "Details.Product.Category");
            this._cancelInvoiceMasterService.CancelInvoiceMaster(invoiceMaster,request.DateCancel);
            _unitOfWork.Commit();
            return Task.FromResult(new CancelInvoiceResponse());
        }
    }

    public class CancelInvoiceRequest : IRequest<CancelInvoiceResponse>
    {
        public long Id { get; set; }
        public DateTime DateCancel { get; set; }
    }
    public class CancelInvoiceResponse
    {
        public string Message { get; set; }
        public CancelInvoiceResponse()
        {
            this.Message = "¡Operación Exitosa!";
        }
    }
    public class CancelInvoiceValidator : AbstractValidator<CancelInvoiceRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICancelInvoiceMasterService _cancelInvoiceMasterService;
        private InvoiceMaster _invoiceMaster;
        public CancelInvoiceValidator(IUnitOfWork unitOfWork, ICancelInvoiceMasterService cancelInvoiceMasterService)
        {
            _unitOfWork = unitOfWork;
            _cancelInvoiceMasterService = cancelInvoiceMasterService;
            RuleFor(x => x.Id).Must(ExistInvoiceMaster).WithMessage(t => $"Factura de id {t.Id} no encontrado");
            RuleFor(a => new { invoiceMaster = a }).Custom((a, context) =>
            {
                if (ExistInvoiceMaster(a.invoiceMaster.Id))
                {
                    _cancelInvoiceMasterService.CanCancelInvoiceMaster(_invoiceMaster).ToValidationFailure(context);
                }
            });
        }
        public bool ExistInvoiceMaster(long idInvoiceMaster)
        {
            _invoiceMaster = _unitOfWork.InvoicesMasterRepository.FindFirstOrDefault(t => t.Id == idInvoiceMaster);
            return _invoiceMaster != null;
        }

    }

   
}
