using AXA.Mandiri.Technical.Test.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Application.Features.User.Command.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Int32>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Int32> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.User
            {
                UserName = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user, cancellationToken);

            return user.Id;
        }
    }
}
