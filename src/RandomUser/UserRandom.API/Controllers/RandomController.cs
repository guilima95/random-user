using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserRandom.API.Controllers.Base;
using UserRandom.Application.UseCases.Contracts;
using UserRandom.Domain.Notification.Contracts;

namespace UserRandom.API.Controllers
{
    [ApiController]
    [Route("api/random")]
    public class RandomController : MainController
    {
        private readonly IAddUser addUser;
        public RandomController(INotifier notifier, IAddUser addUser) : base(notifier)
        {
            this.addUser = addUser;
        }

        [HttpPost("import/{users}")]
        public async Task<IActionResult> Post(int users)
        {
            await addUser.AddUsers(users);
            return CustomResponse();
        }
    }
}
