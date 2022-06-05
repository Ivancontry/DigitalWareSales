using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SysVentas.Application.Clients;
namespace SysVentas.WebApi.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController: Controller
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(RegisterClientRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response =  await _mediator.Send(new GetClientRequest());
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateClientRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("inactive")]
        public async Task<IActionResult> PutInactive(InactiveClientRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("active")]
        public async Task<IActionResult> PutActive(ActiveClientRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
