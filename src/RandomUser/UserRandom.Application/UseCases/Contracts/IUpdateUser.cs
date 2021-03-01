using System.Threading.Tasks;
using UserRandom.Domain.Entities.ValueObjects;

namespace UserRandom.Application.UseCases.Contracts
{
    public interface IUpdateUser
    {
        Task Update(string id, string title, string firstname, string lastName);
        Task UpdateById(string id);

    }
}
