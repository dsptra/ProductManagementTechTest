using AXA.Mandiri.Technical.Test.Application.Contracts;
using AXA.Mandiri.Technical.Test.Domain.Entities;
using AXA.Mandiri.Technical.Test.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(TestContext context) : base(context)
        {
        }

        public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await _context.User
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    user => user.UserName == username,
                    cancellationToken);

        }
    }
}
