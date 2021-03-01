using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserRandom.API.Auth;
using UserRandom.API.Controllers.Base;
using UserRandom.Application.UseCases.Contracts;
using UserRandom.Domain.Entities.ValueObjects;
using UserRandom.Domain.Notification.Contracts;

namespace UserRandom.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : MainController
    {
        private readonly IGetUser user;
        public AuthController(IGetUser user, INotifier notifier) : base(notifier)
        {
            this.user = user;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserResolver model)
        {
            if (string.IsNullOrEmpty(model.Email))
                NotifierError("email empty.");

            var response = new object();

            // Recupera o usuário
            var userApplication = await user.GetByEmail(model.Email);

            // Verifica se o usuário existe
            if (userApplication == null)
                NotifierError("user not found or without permission.");

            else
            {
                // Gera o Token
                model.Email = userApplication.Email.EmailAddress;
                var token = GenerateToken.GetToken(model);

                response = new
                {
                    email = model.Email,
                    name = userApplication.Name.FullName,
                    token = token
                };
            }


            return CustomResponse(response);
        }
    }
}
