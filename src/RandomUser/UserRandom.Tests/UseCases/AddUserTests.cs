using NSubstitute;
using System;
using UserRandom.Application.UseCases;
using UserRandom.Application.UseCases.Contracts;
using UserRandom.Data.ExternalServices.Contracts;
using UserRandom.Domain.DTO;
using UserRandom.Domain.Notification.Contracts;
using UserRandom.Domain.Repositories;
using Xunit;

namespace UserRandom.Tests.UseCases
{
    public class AddUserTests
    {
        [Fact]
        public void Import_Success_And_AddUser()
        {
            // ARRANGE
            var result = new Result
            {
                cell = "",
                dob = new Dob
                {
                    age = 25,
                    date = DateTime.Now

                },
                email = "",
                gender = "",
                location = new Location
                {
                    city = "",
                    coordinates = new Coordinates
                    {
                        latitude = "",
                        longitude = ""
                    },
                    country = "",
                    postcode = "",
                    state = "",
                    street = new Street
                    {
                        name = "",
                        number = 1

                    },
                    timezone = new Timezone
                    {
                        description = "",
                        offset = ""
                    }
                },
                login = new Login
                {
                    md5 = "",
                    password = "",
                    salt = "",
                    sha1 = "",
                    sha256 = "",
                    username = "",
                    uuid = ""
                },
                name = new Name
                {
                    first = "",
                    last = "",
                    title = ""
                },
                nat = "",
                phone = "",
                picture = new Picture
                {
                    large = "",
                    medium = "",
                    thumbnail = ""
                },
                registered = new Registered
                {
                    age = 25,
                    date = DateTime.Now
                }
            };

            var objResult = new RootObject
            {
                results = new System.Collections.Generic.List<Result>()
            };

            objResult.results.Add(result);


            var mockRepository = Substitute.For<IRandomRepository>();
            var mockUserRepository = Substitute.For<IUserRepository>();
            var mockNotifications = Substitute.For<INotifier>();

            mockRepository.GetUsersRandom(100).Returns(objResult);

            // ACT
            IAddUser useCase = new AddUser(mockRepository, mockUserRepository, mockNotifications);


            // ASSERT
            Assert.NotNull(useCase.AddUsers(1));
        }
    }
}
