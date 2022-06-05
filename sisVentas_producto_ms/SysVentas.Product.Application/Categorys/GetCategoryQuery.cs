using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SysVentas.Application.Categorys.ModelView;
using SysVentas.Domain.Contracts;
namespace SysVentas.Application.Categorys
{
    public class GetCategoryQuery : IRequestHandler<GetCategoryRequest, GetCategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCategoryQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Task<GetCategoryResponse> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var categories = _unitOfWork.CategorysRepository.FindBy(t=> t.Status != "IN").ToList();
            var categoryModelView = new CategoryModelView();
            var categorysModelViws =  categoryModelView.ToListEntity(categories);
            return Task.FromResult(new GetCategoryResponse(categorysModelViws));
        }
    }
    public class GetCategoryRequest: IRequest<GetCategoryResponse>
    {
    }
    public class GetCategoryResponse
    {
        public List<CategoryModelView> Categories { get; set; }
        public GetCategoryResponse(List<CategoryModelView> categoryModelViews)
        {
            Categories = categoryModelViews;
        }
    }
}
