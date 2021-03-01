using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserRandom.Domain.Entities;

namespace UserRandom.Application.UseCases.Contracts
{
    public interface IGetUser
    {
        Task<User> GetById(string id);
        Task<User> GetByEmail(string email);
        Task<IList<User>> GetAll();
        Task<string> Get();
    }
}
