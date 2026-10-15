using AXA.Mandiri.Technical.Test.Domain.DTO;

namespace AXA.Mandiri.Technical.Test.Application.Contracts
{
    public interface IJwtTokenService
    {
        JWTDto GenerateJwtToken(string userName);
    }
}
