using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SysVentas.Application.Base;
using SysVentas.Domain.Contracts;
using SysVentas.Domain.Entities.Categorys;
namespace SysVentas.Application.Categorys.Products
{
    public class UpdateProductCommand : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateProductRequest> _validator;
        public UpdateProductCommand(IUnitOfWork unitOfWork, IValidator<UpdateProductRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var category = _unitOfWork.CategorysRepository.FindFirstOrDefault(t=> t.Id == request.CategoryId);
            category.EditProduct(idProduct:request.Id,code: request.Code, name: request.Name, amount: request.Amount);
            _unitOfWork.Commit();
            return Task.FromResult(new UpdateProductResponse(request.Id));
        }
    }
    public record UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public long CategoryId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
    public record UpdateProductResponse
    {
        private long Id { get; set; }

        public string Message { get; set; }

        public UpdateProductResponse(long id)
        {
            Id = id;
            Message = "¡Operación Exitosa!";
        }
    }

    public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        private Category _category;
        public UpdateProductValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Code).NotEmpty().WithMessage("Nombre no puede ser vacío");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Código no puede ser vacío");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Fecha de registo no puede ser vacía");
            RuleFor(x => x.CategoryId).Must(ExistCategory).WithMessage($"Categoria no encontrada");
            RuleFor(a => new { productRequest = a }).Custom((a, context) =>
            {
                if (ExistCategory(a.productRequest.CategoryId)) {
                    _category.CanEditProduct(a.productRequest.Id, a.productRequest.Amount).ToValidationFailure(context);
                }

            });
        }

        private bool ExistCategory(long id)
        {
            _category = _unitOfWork.CategorysRepository.FindFirstOrDefault(t => t.Id == id, includeProperties: "Products");
            return _category != null;
        }

       
    }
}
