using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserRandom.Application.UseCases.Contracts;
using UserRandom.Domain.Notification.Contracts;
using UserRandom.Domain.Repositories;
using UserRandom.Domain.Services.Base;

namespace UserRandom.Application.UseCases
{
    public class DeleteUser : NotificationService, IDeleteUser
    {
        private readonly IUserRepository userRepository;
        public DeleteUser(INotifier notifier, IUserRepository userRepository) : base(notifier)
        {
            this.userRepository = userRepository;
        }

        public async Task DeleteById(string id)
        {
            var user = await userRepository.FindByIdAsync(id);

            if (user == null)
                Notifier($"User not found.");

            if (!HasNotification())
                await userRepository.DeleteByIdAsync(id);
        }

        public async Task Delete(string email)
        {
            var user = await userRepository.FindOneAsync(x => x.Email.EmailAddress == email);

            if (user == null)
                Notifier($"User not found: {email}");

            if (!HasNotification())
                await userRepository.DeleteOneAsync(x => x.Email.EmailAddress == email);

        }
    }
}
