using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SysVentas.Application.Categorys.ModelView;
using SysVentas.Domain.Contracts;
namespace SysVentas.Application.Categorys.Products
{
    
    public class GetProductForCodeQuery : IRequestHandler<GetProductForCodeRequest, GetProductForCodeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductForCodeQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Task<GetProductForCodeResponse> Handle(GetProductForCodeRequest request, CancellationToken cancellationToken)
        {
            var product = _unitOfWork.CategorysRepository.GetProductForCode(request.Code);
            var productModelView = new ProductModelView().ToDTO(product);
            return Task.FromResult(new GetProductForCodeResponse(productModelView));
        }
    }
    public class GetProductForCodeRequest : IRequest<GetProductForCodeResponse>
    {
        public string Code { get; set; }
    }
    public class GetProductForCodeResponse
    {     
        public ProductModelView Product { get; set; }
        public GetProductForCodeResponse(ProductModelView productModelView)
        {
            Product = productModelView;
        }
    }

    public class GetProductForCodeValidator: AbstractValidator<GetProductForCodeRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductForCodeValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Code).Must(ExistProduct).WithMessage($"Producto no encontrado");
        }

        private bool ExistProduct(string code)
        {
            var category = _unitOfWork.CategorysRepository.GetProductForCode(code);
            return category is not null;
        }
    }
}
