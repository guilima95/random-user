using System;
using System.Collections.Generic;
using System.Text;
using UserRandom.Data.MongoDb;
using UserRandom.Data.MongoDb.Contracts;
using UserRandom.Domain.Entities;
using UserRandom.Domain.Repositories;

namespace UserRandom.Data.Repositories
{
    public class UserRepository : MongoRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDbSettings context) : base(context)
        {
        }
    }
}
