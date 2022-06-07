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
    
    public class GetProductsQuery : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductsQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = _unitOfWork.CategorysRepository.GetProducts();
            var productsModelView = new ProductModelView().ToListDTO(products);
            return Task.FromResult(new GetProductsResponse(productsModelView));
        }
    }
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        
    }
    public class GetProductsResponse
    {
        public List<ProductModelView> Products { get; set; }
        

        public GetProductsResponse(List<ProductModelView> productsModelView)
        {
            Products = productsModelView;
        }
    }

    
}
