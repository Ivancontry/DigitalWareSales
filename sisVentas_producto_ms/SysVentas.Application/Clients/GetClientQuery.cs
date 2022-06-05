using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SysVentas.Application.Clients.ModelView;
using SysVentas.Domain.Contracts;
namespace SysVentas.Application.Clients
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
            var clientModelViews = clientModelView.ToListDTO(clients);
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
