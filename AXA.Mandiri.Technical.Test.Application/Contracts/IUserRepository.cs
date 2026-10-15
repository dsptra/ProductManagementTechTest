using AXA.Mandiri.Technical.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Application.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    }
}
