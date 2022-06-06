using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SysVentas.Domain.Contracts;
using SysVentas.Domain.Entities.Clients;
namespace SysVentas.Application.Clients
{
    public class InactiveClientCommand : IRequestHandler<InactiveClientRequest, InactiveClientResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<InactiveClientRequest> _validator;
        public InactiveClientCommand(IUnitOfWork unitOfWork, IValidator<InactiveClientRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public Task<InactiveClientResponse> Handle(InactiveClientRequest request, CancellationToken cancellationToken)
        {
            var client = _unitOfWork.ClientsRepository.FindFirstOrDefault(t => t.Id == request.Id);
            client.Inactive();
            _unitOfWork.Commit();
            return Task.FromResult(new InactiveClientResponse(request.Id));
        }
    }
    public record InactiveClientRequest : IRequest<InactiveClientResponse>
    {
        public long Id { get; set; }
    }
    public record InactiveClientResponse
    {
        public long Id { get; set; }

        public string Message { get; set; }

        public InactiveClientResponse(long id)
        {
            this.Id = id;
            this.Message = "¡Operación Exitosa!";
        }
    }

    public class InactiveClientValidator : AbstractValidator<InactiveClientRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

    
        public InactiveClientValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Id).Must(ExistClient).WithMessage($"Cliente no encontrado");           

        }
        private bool ExistClient(long id)
        {
            var client = _unitOfWork.ClientsRepository.FindFirstOrDefault(t => t.Id == id);
            return client is not null;
        }
        
    }
}
