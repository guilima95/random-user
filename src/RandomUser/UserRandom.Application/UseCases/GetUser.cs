using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRandom.Application.UseCases.Contracts;
using UserRandom.Domain.Entities;
using UserRandom.Domain.Notification.Contracts;
using UserRandom.Domain.Repositories;
using UserRandom.Domain.Services.Base;

namespace UserRandom.Application.UseCases
{
    public class GetUser : NotificationService, IGetUser
    {
        private readonly IUserRepository userRepository;
        public GetUser(INotifier notifier, IUserRepository userRepository) : base(notifier)
        {
            this.userRepository = userRepository;
        }

        public async Task<string> Get()
        {
            return await Task.Run(() => "REST Back-end Challenge Running");
        }

        public Task<IList<User>> GetAll()
        {
            var users = userRepository.FindAll();

            return users;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await userRepository.FindOneAsync(x => x.Email.EmailAddress == email);
            return user;
        }

        public async Task<User> GetById(string id)
        {
            var user = await userRepository.FindByIdAsync(id);
            return user;
        }
    }
}
