using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SysVentas.Application.Base;
using SysVentas.Domain.Contracts;
using SysVentas.Domain.Entities.Categorys;
using SysVentas.Domain.Entities.Invoices;
namespace SysVentas.Application.Invoices
{
    public class RegisterInvoiceCommand : IRequestHandler<RegisterInvoiceRequest, RegisterInvoiceResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<RegisterInvoiceRequest> _validator;
        public RegisterInvoiceCommand(IUnitOfWork unitOfWork, IValidator<RegisterInvoiceRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public Task<RegisterInvoiceResponse> Handle(RegisterInvoiceRequest request, CancellationToken cancellationToken)
        {
            var invoice = new InvoiceMaster(request.Date, request.ClientId);
            request.Products.ForEach(p =>
            {
                var product = _unitOfWork.CategorysRepository.GetProduct(p.ProductId);
                invoice.AddDetail(product.Id, Math.Abs(p.Amount), product.Price);
                product.Category.UpdateStockProduct(product.Id, p.Amount);
            });
            _unitOfWork.InvoicesMasterRepository.Add(invoice);
            _unitOfWork.Commit();
            return Task.FromResult(new RegisterInvoiceResponse());
        }
    }

    public class RegisterInvoiceRequest : IRequest<RegisterInvoiceResponse>
    {
        public long ClientId { get; set; }
        public DateTime Date { get; set; }
        public List<ClientProductModelView> Products { get; set; }
    }
    public class RegisterInvoiceResponse
    {
        public string Message { get; set; }
        public RegisterInvoiceResponse()
        {
            this.Message = "¡Operación Exitosa!";
        }
    }
    public class RegisterInvoiceValidator : AbstractValidator<RegisterInvoiceRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductValidator ProductValidator { get; set; }
        public RegisterInvoiceValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ProductValidator = new ProductValidator(this._unitOfWork);
            RuleFor(x => x.ClientId).Must(ExistirClient).WithMessage(t => $"Cliente de id {t.ClientId} no encontrado");
            RuleForEach(x => x.Products).SetValidator(ProductValidator).When(x => x.Products.Count > 0);
        }
        public bool ExistirClient(long clientId)
        {
            var client = _unitOfWork.ClientsRepository.FindFirstOrDefault(t => t.Id == clientId);
            return client != null;
        }

    }

    public class ProductValidator : AbstractValidator<ClientProductModelView>
    {
        private readonly IUnitOfWork _unitOfWork;
        public Product Product { get; set; }
        public ProductValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.ProductId).Must(ExistirProduct).WithMessage(t => $"Producto de id {t.ProductId} no encontrado");
            RuleFor(a => new { product = a }).Custom((a, context) =>
            {
                if (ExistirProduct(a.product.ProductId))
                {
                    this.Product.Category.CanUpdateStockProduct(a.product.ProductId, a.product.Amount).ToValidationFailure(context);
                }
            }).When(t=> Product is not null);
        }
        public bool ExistirProduct(long productId)
        {
            Product = _unitOfWork.CategorysRepository.GetProduct(productId);
            return Product is not null;
        }
    }

    public class ClientProductModelView
    {
        public long ProductId { get; set; }
        public decimal Amount { get; set; }
    }
}
