using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SysVentas.Domain.Contracts;
using SysVentas.Domain.Entities.Clients;
namespace SysVentas.Application.Clients
{
    public class RegisterClientCommand : IRequestHandler<RegisterClientRequest, RegisterClientResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<RegisterClientRequest> _validator;
        public RegisterClientCommand(IUnitOfWork unitOfWork, IValidator<RegisterClientRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public Task<RegisterClientResponse> Handle(RegisterClientRequest request, CancellationToken cancellationToken)
        {
            var client = new Client(request.Identification,request.Name,request.Phone,request.BirthDay,request.Address,request.Email);
            _unitOfWork.ClientsRepository.Add(client);
            _unitOfWork.Commit();
            return Task.FromResult(new RegisterClientResponse(client.Id));
        }
    }
    public record RegisterClientRequest : IRequest<RegisterClientResponse>{
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
    public record RegisterClientResponse
    {
        public long Id { get; set; }

        public string Message { get; set; }

        public RegisterClientResponse(long id)
        {
            Id = id;
            Message = "¡Operación Exitosa!";
        }
    }

    public class RegisterClientValidator : AbstractValidator<RegisterClientRequest> {
        private readonly IUnitOfWork _unitOfWork;        
        public RegisterClientValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Identification).NotEmpty().WithMessage("Identificación no puede ser vacía");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nombre no puede ser vacío");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Dirección no puede ser vacía");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Correo es invalido");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Teléfono no puede ser vacío");
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage("Fecha de nacimiento no puede ser vacía");
            RuleFor(x => x.Identification).Must(ExistClient).WithMessage($"El código de esta Categoría ya se encuentra registrado");
        }

        private bool ExistClient(string identification)
        {
            var client = _unitOfWork.ClientsRepository.FindFirstOrDefault(t=> t.Identification == identification);
            return client == null;
        }
    }
}
