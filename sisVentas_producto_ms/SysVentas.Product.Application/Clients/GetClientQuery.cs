using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SysVentas.Products.Application.Clients.ModelView;
using SysVentas.Products.Application.Categorys.ModelView;
using SysVentas.Products.Domain.Base;

namespace SysVentas.Products.Application.Clients
{
    public class GetClientQuery : IRequestHandler<GetClientRequest, GetClientResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetClientQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Task<GetClientResponse> Handle(GetClientRequest request, CancellationToken cancellationToken)
        {
            var clients = _unitOfWork.ClientsRepository.FindBy(t=> t.Status != "IN").ToList();
            var clientModelView = new ClientModelView();
            var clientModelViews = clientModelView.ToListEntity(clients);
            return Task.FromResult(new GetClientResponse(clientModelViews));
        }
    }
    public class GetClientRequest: IRequest<GetClientResponse>
    {
    }
    public class GetClientResponse
    {
        public List<ClientModelView> Clients { get; set; }
        public GetClientResponse(List<ClientModelView> categoryModelViews)
        {
            Clients= categoryModelViews;
        }
    }
}
