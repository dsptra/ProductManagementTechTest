using AXA.Mandiri.Technical.Test.Application.Contracts;
using AXA.Mandiri.Technical.Test.Domain.DTO;
using MediatR;

namespace AXA.Mandiri.Technical.Test.Application.Features.User.Query.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, JWTDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<JWTDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                throw new UnauthorizedAccessException("Invalid username or password.");

            return _jwtTokenService.GenerateJwtToken(user.UserName);
        }
    }
}
