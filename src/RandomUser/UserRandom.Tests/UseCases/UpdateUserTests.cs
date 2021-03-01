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
    public class UpdateUserTests
    {
        private const string FirstNameInvalid = "";

        private const string FirstName = "Thomas";
        private const string LastName = "Smith";
        private const string Title = "Mr";


        private const string idValido = "60259848d73bf52beac1fd25";



        IUserRepository mockRepository = NSubstitute.Substitute.For<IUserRepository>();
        private INotifier mockNotifier = NSubstitute.Substitute.For<INotifier>();

        private IUpdateUser appService;
        public UpdateUserTests()
        {
            appService = new UpdateUser(mockRepository, mockNotifier);
        }

        [Fact]
        public void Update_User_Not_Found()
        {
            User user = null;
            mockRepository.FindById(Arg.Any<string>()).Returns(user);

            var notification = new Notification("");
            mockNotifier.Handle(notification);
            var erros = mockNotifier.GetNotifications();

            mockNotifier.HasNotification().Returns(true);

            appService.Update("60259848d73bfsss5", Title, FirstName, LastName);

            Assert.True(mockNotifier.HasNotification());

        }

        [Fact]
        public void Update_User()
        {
            var user = new User
            {
                Name = new Domain.Entities.ValueObjects.Name(Title, FirstName, LastName)
            };

            mockRepository.FindByIdAsync(Arg.Any<string>()).Returns(user);

            appService.Update(idValido, Title, FirstName, LastName);

            Assert.False(mockNotifier.HasNotification());
        }
        [Fact]
        public void Update_User_Name_Invalid()
        {
            var user = new User
            {
                Name = new Domain.Entities.ValueObjects.Name(Title, FirstName, LastName)
            };

            mockRepository.FindByIdAsync(Arg.Any<string>()).Returns(user);

            var notification = new Notification("");

            mockNotifier.Handle(notification);

            mockNotifier.HasNotification().Returns(true);

            appService.Update(idValido, Title, FirstNameInvalid, LastName);

            Assert.True(mockNotifier.HasNotification());
        }
    }
}
