using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SysVentas.Products.Domain;
using SysVentas.Products.Domain.Base;
using SysVentas.Products.Domain.Entities.Clients;

namespace SysVentas.Products.Application.Clients
{
    public class ActiveClientCommand : IRequestHandler<ActiveClientRequest, ActiveClientResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ActiveClientRequest> _validator;
        public ActiveClientCommand(IUnitOfWork unitOfWork, IValidator<ActiveClientRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public Task<ActiveClientResponse> Handle(ActiveClientRequest request, CancellationToken cancellationToken)
        {
            var client = _unitOfWork.ClientsRepository.FindFirstOrDefault(t => t.Id == request.Id);
            client.Active();
            _unitOfWork.Commit();
            return Task.FromResult(new ActiveClientResponse(request.Id));
        }
    }
    public record ActiveClientRequest : IRequest<ActiveClientResponse>
    {        
        public long Id { get; set; }
    }
    public record ActiveClientResponse
    {
        public long Id { get; set; }

        public string Message { get; set; }

        public ActiveClientResponse(long id)
        {
            this.Id = id;
            this.Message = "¡Operación Exitosa!";
        }
    }

    public class ActiveClientValidator : AbstractValidator<ActiveClientRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        private Client _client;
        public ActiveClientValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Id).Must(ExistClient).WithMessage($"Cliente no encontrado");

        }

        private bool ExistClient(long id)
        {
            _client = _unitOfWork.ClientsRepository.FindFirstOrDefault(t => t.Id == id);
            return _client != null;
        }
        

    }
}
