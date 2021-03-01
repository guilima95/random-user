using System.Threading.Tasks;
using UserRandom.Domain.DTO;

namespace UserRandom.Data.ExternalServices.Contracts
{
    public interface IRandomRepository
    {
        Task<RootObject> GetUsersRandom(int count);
    }
}
