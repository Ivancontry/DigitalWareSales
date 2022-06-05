using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SysVentas.Domain.Contracts;
namespace SysVentas.Application.Categorys
{
    public class UpdateProductCommand : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateCategoryRequest> _validator;
        public UpdateProductCommand(IUnitOfWork unitOfWork, IValidator<UpdateCategoryRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _unitOfWork.CategorysRepository.FindFirstOrDefault(t => t.Id == request.Id);
            category.Editar(request.Code, request.Name);
            _unitOfWork.Commit();
            return Task.FromResult(new UpdateCategoryResponse(category.Id));
        }
    }
    public record UpdateCategoryRequest : IRequest<UpdateCategoryResponse>{
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

    }
    public record UpdateCategoryResponse
    {
        private long id { get; set; }

        public string Message { get; set; }

        public UpdateCategoryResponse(long id)
        {
            this.id = id;
            this.Message = "¡Operación Exitosa!";
        }
    }

    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequest> {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCategoryValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Code).NotEmpty().WithMessage("Nombre no puede ser vacío");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Código no puede ser vacío");
            RuleFor(x => x.Id).Must(ExistCategory).WithMessage($"El código de esta Categoría ya se encuentra registrado");
        }

        private bool ExistCategory(long id)
        {
            var category = _unitOfWork.CategorysRepository.FindFirstOrDefault(t=> t.Id == id);
            return category != null;
        }
    }
}
