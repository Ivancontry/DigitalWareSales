using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SysVentas.Application.Clients.ModelView;
using SysVentas.Domain.Contracts;
namespace SysVentas.Application.Clients
{
    public class GetClientForIdentificationQuery : IRequestHandler<GetClientForIdentificationRequest, GetClientForIdentificationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetClientForIdentificationQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Task<GetClientForIdentificationResponse> Handle(GetClientForIdentificationRequest request, CancellationToken cancellationToken)
        {
            var client = _unitOfWork.ClientsRepository.FindFirstOrDefault(t=> t.Identification == request.Identification);
            var clientModelView = new ClientModelView().ToDTO(client);
            return Task.FromResult(new GetClientForIdentificationResponse(clientModelView));
        }
    }
    public class GetClientForIdentificationRequest: IRequest<GetClientForIdentificationResponse>
    {
        public string Identification { get; set; }
    }
    public class GetClientForIdentificationResponse
    {
        public ClientModelView Client { get; set; }
        public GetClientForIdentificationResponse(ClientModelView clientModelView)
        {
            Client= clientModelView;
        }
    }

    public class GetClientForIdentificationValidator : AbstractValidator<GetClientForIdentificationRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetClientForIdentificationValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Identification).Must(ExistClient).WithMessage($"Cliente no encontrado");

        }
        private bool ExistClient(string identification)
        {
            var client = _unitOfWork.ClientsRepository.FindFirstOrDefault(t => t.Identification == identification && t.Status != "IN");
            return client is not null;
        }
    }
}
