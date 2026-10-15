using AXA.Mandiri.Technical.Test.Application.Features.User.Command.AddUser;
using AXA.Mandiri.Technical.Test.Application.Features.User.Query.Login;
using AXA.Mandiri.Technical.Test.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AXA.Mandiri.Technical.Test.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new LoginQuery(request.Username, request.Password), cancellationToken);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AddUserRequestDto request, CancellationToken cancellationToken)
        {
            var userId = await _mediator.Send(new AddUserCommand(request.Username, request.Password), cancellationToken);
            return CreatedAtAction(nameof(Register), new { id = userId });
        }
    }
}
