using System;
using System.Collections.Generic;
using System.Text;
using UserRandom.Domain.Entities;

namespace UserRandom.Domain.Repositories
{
    public interface IUserRepository : IMongoRepository<User>
    {
    }
}
