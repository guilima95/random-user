using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRandom.Application.UseCases.Contracts;
using UserRandom.Data.ExternalServices.Contracts;
using UserRandom.Domain.DTO;
using UserRandom.Domain.Entities;
using UserRandom.Domain.Notification.Contracts;
using UserRandom.Domain.Repositories;
using UserRandom.Domain.Services.Base;

namespace UserRandom.Application.UseCases
{
    public class AddUser : NotificationService, IAddUser
    {
        private readonly IRandomRepository randomUser;
        private readonly IUserRepository userRepository;

        public AddUser(IRandomRepository randomUser, IUserRepository userRepository, INotifier notifier) : base(notifier)
        {
            this.randomUser = randomUser;
            this.userRepository = userRepository;
        }

        public async Task AddUsers(int count)
        {
            if (count <= 0)
                Notifier($"count user import not equal: {count}");

            List<User> users = new List<User>();

            // get random user api
            var result = await randomUser.GetUsersRandom(count);

            // valid rule for max import in day
            if (await ValidImportLimit(count))
                Notifier($"import max 2000 users. not supported: {count}");
            else
            {
                foreach (var item in result.results)
                {
                    var user = UserModel.UserDTO(item);
                    users.Add(user);
                }
            }

            // add user
            if (!HasNotification())
                await userRepository.InsertManyAsync(users);
        }

        private async Task<bool> ValidImportLimit(int users)
        {
            // date saved in last 24h old
            var userLastImported = await userRepository.FindOneAsync(a => a.Imported_t > DateTime.Now.AddHours(-24) && a.Imported_t <= DateTime.Now);

            if (userLastImported != null)
                Notifier($"imported not allowed, one import only day.");

            if (users == 2000)
                return true;
            return false;
        }
    }
}

