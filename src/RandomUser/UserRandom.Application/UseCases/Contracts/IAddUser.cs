using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserRandom.Data.ExternalServices;
using UserRandom.Domain.Entities;

namespace UserRandom.Application.UseCases.Contracts
{
    public interface IAddUser
    {
        Task AddUsers(int count);
    }
}
