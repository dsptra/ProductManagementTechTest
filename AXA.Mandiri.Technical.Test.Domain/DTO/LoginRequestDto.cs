using System.ComponentModel.DataAnnotations;

namespace AXA.Mandiri.Technical.Test.Domain.DTO
{
    public class LoginRequestDto
    {
        [Required]
        public string Username { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
    }
}
