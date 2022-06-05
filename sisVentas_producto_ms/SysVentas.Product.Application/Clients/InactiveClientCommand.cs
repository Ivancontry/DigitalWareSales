using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SysVentas.Products.Domain.Base;
using SysVentas.Products.Domain.Entities.Clients;

namespace SysVentas.Products.Application.Clients
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

        private Client _client;
        public InactiveClientValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Id).Must(ExistCategory).WithMessage($"Categoria no encontrada");           

        }
        private bool ExistCategory(long id)
        {
            _client = _unitOfWork.ClientsRepository.FindFirstOrDefault(t => t.Id == id);
            return _client != null;
        }
        
    }
}
