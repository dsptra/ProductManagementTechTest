using System;
using System.Collections.Generic;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Domain.DTO
{
    public class JWTDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string TokenType { get; set; } = "Bearer";
        public DateTime ExpiresAt { get; set; }
    }
}
