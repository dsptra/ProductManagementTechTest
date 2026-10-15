using AXA.Mandiri.Technical.Test.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Application.Features.User.Query.Login
{
    public class LoginQuery : IRequest<JWTDto>
    {
        public LoginQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
