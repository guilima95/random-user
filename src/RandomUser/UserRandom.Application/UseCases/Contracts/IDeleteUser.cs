using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserRandom.Domain.Entities.ValueObjects;

namespace UserRandom.Application.UseCases.Contracts
{
    public interface IDeleteUser
    {
        Task DeleteById(string id);
        Task Delete(string email);
    }
}
