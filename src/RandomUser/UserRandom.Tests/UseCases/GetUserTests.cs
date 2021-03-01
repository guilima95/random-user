using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using UserRandom.Application.UseCases;
using UserRandom.Application.UseCases.Contracts;
using UserRandom.Domain.Entities;
using UserRandom.Domain.Notification;
using UserRandom.Domain.Notification.Contracts;
using UserRandom.Domain.Repositories;
using Xunit;

namespace UserRandom.Tests.UseCases
{
    public class GetUserTests
    {
        private const string Email_Invalido = "emailinvalido@gmail.com";
        private const string Email_Valido = "thomas.smith@example.com";

        IUserRepository mockRepository = NSubstitute.Substitute.For<IUserRepository>();
        private INotifier mockNotifier = NSubstitute.Substitute.For<INotifier>();

        private IGetUser appService;
        public GetUserTests()
        {
            appService = new GetUser(mockNotifier, mockRepository);
        }

        [Fact]
        public void Get_User_Not_Found()
        {
            User user = null;
            mockRepository.FindOneAsync(Arg.Any<Expression<Func<User, bool>>>()).Returns(user);

            var notification = new Notification("");
            mockNotifier.Handle(notification);
            var erros = mockNotifier.GetNotifications();

            mockNotifier.HasNotification().Returns(true);

            appService.GetByEmail(Email_Invalido);

            Assert.True(mockNotifier.HasNotification());

        }

        [Fact]
        public void Get_User_By_Email()
        {
            var user = new User
            {
                Email = new Domain.Entities.ValueObjects.Email(Email_Valido)
            };

            mockRepository.FindOneAsync(Arg.Any<Expression<Func<User, bool>>>()).Returns(user);

            appService.GetByEmail(Email_Valido);

            Assert.False(mockNotifier.HasNotification());
        }
    }
}
