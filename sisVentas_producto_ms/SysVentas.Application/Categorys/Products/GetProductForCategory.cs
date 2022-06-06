using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SysVentas.Application.Categorys.ModelView;
using SysVentas.Domain.Contracts;
namespace SysVentas.Application.Categorys.Products
{
    
    public class GetProductForCategoryQuery : IRequestHandler<GetProductForCategoryRequest, GetProductForCategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductForCategoryQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Task<GetProductForCategoryResponse> Handle(GetProductForCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _unitOfWork.CategorysRepository.FindFirstOrDefault(t=> t.Id == request.CategoryId,includeProperties:"Products");
            var productModelView = new ProductModelView();
            var productsModelViws = productModelView.ToListDTO(category.Products.Where(t=> t.Status!="IN").ToList());
            return Task.FromResult(new GetProductForCategoryResponse(category.Id,productsModelViws));
        }
    }
    public class GetProductForCategoryRequest : IRequest<GetProductForCategoryResponse>
    {
        public long CategoryId { get; set; }
    }
    public class GetProductForCategoryResponse
    {
        public long CategoryId { get; set; }
        public List<ProductModelView> Products { get; set; }
        public GetProductForCategoryResponse(long categoryId,List<ProductModelView> categoryModelViews)
        {
            Products = categoryModelViews;
            CategoryId = categoryId;
        }
    }

    public class GetProductForCategoryValidator: AbstractValidator<GetProductForCategoryRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductForCategoryValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.CategoryId).Must(ExistCategory).WithMessage($"Categoría no encontrada");
        }

        private bool ExistCategory(long id)
        {
            var category = _unitOfWork.CategorysRepository.FindFirstOrDefault(t => t.Id == id);
            return category is not null;
        }
    }
}
