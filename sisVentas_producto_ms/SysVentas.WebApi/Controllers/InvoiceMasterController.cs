using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SysVentas.Application.Clients;
using SysVentas.Application.Invoices;

namespace SysVentas.WebApi.Controllers
{
    [Route("api/invoice")]
    [ApiController]
    public class InvoiceMasterController : Controller
    {
        private readonly IMediator _mediator;

        public InvoiceMasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(RegisterInvoiceRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response =  await _mediator.Send(new GetInvoicesRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetForId(long id)
        {
            var response = await _mediator.Send(new GetInvoiceForIdRequest { Id = id});
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutCancel(CancelInvoiceRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        
    }
}
