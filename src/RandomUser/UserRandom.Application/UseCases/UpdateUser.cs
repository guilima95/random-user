using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserRandom.Application.UseCases.Contracts;
using UserRandom.Domain.Entities.ValueObjects;
using UserRandom.Domain.Notification;
using UserRandom.Domain.Notification.Contracts;
using UserRandom.Domain.Repositories;
using UserRandom.Domain.Services.Base;
using UserRandom.Domain.Validations;

namespace UserRandom.Application.UseCases
{
    public class UpdateUser : NotificationService, IUpdateUser
    {
        private IUserRepository userRepository;
        public UpdateUser(IUserRepository userRepository, INotifier notifier) : base(notifier)
        {
            this.userRepository = userRepository;
        }
        public async Task Update(string id, string title, string firstname, string lastName)
        {
            var user = await userRepository.FindByIdAsync(id);

            if (user == null)
                Notifier($"User not found: {firstname}");

            var nameUpdate = new Name(title, firstname, lastName);


            if (!HasNotification())
            {
                user.Name = nameUpdate;
                await userRepository.ReplaceOneAsync(user);
            }
        }

        public async Task UpdateById(string id)
        {
            var user = await userRepository.FindByIdAsync(id);

            if (user == null)
                Notifier($"User not found.");

            if (!HasNotification())
                await userRepository.ReplaceOneAsync(user);

        }
    }
}
