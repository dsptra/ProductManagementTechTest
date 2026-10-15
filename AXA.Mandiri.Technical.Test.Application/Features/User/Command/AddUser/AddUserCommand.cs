using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Application.Features.User.Command.AddUser
{
    public class AddUserCommand : IRequest<Int32>
    {
        public AddUserCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public String Username { get; set; }
        public String Password { get; set; }
    }
}
