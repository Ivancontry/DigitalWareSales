using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SysVentas.Domain.Contracts;
namespace SysVentas.Application.Clients
{
    public class UpdateClientCommand : IRequestHandler<UpdateClientRequest, UpdateClientResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateClientRequest> _validator;
        public UpdateClientCommand(IUnitOfWork unitOfWork, IValidator<UpdateClientRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public Task<UpdateClientResponse> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
        {
            var client = _unitOfWork.ClientsRepository.FindFirstOrDefault(t => t.Id == request.Id);
            client.Edit(request.Identification, request.Name, request.Phone, request.Age, request.Address, request.Email);
            _unitOfWork.Commit();
            return Task.FromResult(new UpdateClientResponse(client.Id));
        }
    }
    public record UpdateClientRequest : IRequest<UpdateClientResponse>{
        public long Id { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }
    public record UpdateClientResponse
    {
        public long Id { get; set; }

        public string Message { get; set; }

        public UpdateClientResponse(long id)
        {
            this.Id = id;
            this.Message = "¡Operación Exitosa!";
        }
    }

    public class UpdateClientValidator : AbstractValidator<UpdateClientRequest> {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateClientValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Identification).NotEmpty().WithMessage("Identificación no puede ser vacía");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nombre no puede ser vacío");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Dirección no puede ser vacía");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Correo es invalido");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Teléfono no puede ser vacío");
            RuleFor(x => x.Identification).Must(ExistClient).WithMessage($"El código de esta Categoría ya se encuentra registrado");
        }

        private bool ExistClient(string identification)
        {
            var client = _unitOfWork.ClientsRepository.FindFirstOrDefault(t => t.Identification == identification);
            return client != null;
        }
    }
}
