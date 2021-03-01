using System;
using System.Collections.Generic;
using System.Text;
using UserRandom.Domain.Entities;
using UserRandom.Domain.Entities.ValueObjects;
using UserRandom.Domain.Enums;

namespace UserRandom.Domain.DTO
{
    public static class UserModel
    {
        public static Entities.User UserDTO(Result item)
        {
            var email = new Email(item.email);
            var coordinates = new Domain.Entities.ValueObjects.Coordinates
            {
                Latitude = item.location.coordinates.latitude,
                Longitude = item.location.coordinates.longitude
            };

            var street = new Domain.Entities.ValueObjects.Street
            {
                Name = item.location.street.name,
                Number = item.location.street.number
            };

            var timezone = new Domain.Entities.ValueObjects.Timezone
            {
                Description = item.location.timezone.description,
                Offset = item.location.timezone.offset
            };

            var location = new Domain.Entities.Location
            {
                City = item.location.city,
                Coordinates = coordinates,
                Country = item.location.country,
                Postcode = item.location.postcode,
                State = item.location.state,
                Street = street,
                Timezone = timezone
            };

            var phoneNumber = new Domain.Entities.PhoneNumber(item.phone);

            var name = new Domain.Entities.ValueObjects.Name(item.name.title, item.name.first, item.name.last);

            var login = new Domain.Entities.ValueObjects.Login
            {
                Id = item.login.uuid,
                Md5 = item.login.md5,
                Password = item.login.password,
                Salt = item.login.salt,
                Sha1 = item.login.sha1,
                Sha256 = item.login.sha256,
                Username = item.login.username
            };

            var dob = new Domain.Entities.ValueObjects.Dob
            {
                Age = item.dob.age,
                Date = item.dob.date
            };

            var registered = new Domain.Entities.ValueObjects.Registered
            {
                Age = item.registered.age,
                Date = item.registered.date
            };

            var image = new Image(item.picture.thumbnail);

            var user = new User
            {
                Cell = item.cell,
                Dob = dob,
                Email = email,
                Gender = item.gender,
                Status = RandomStatus.Published,
                Imported_t = DateTime.Now,
                Location = location,
                Login = login,
                Name = name,
                Nat = item.nat,
                Phone = phoneNumber,
                Picture = image,
                Registered = registered

            };

            return user;
        }

    }


    #region Map object result


    public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }

    public class Coordinates
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class Timezone
    {
        public string offset { get; set; }
        public string description { get; set; }
    }

    public class Street
    {
        public int number { get; set; }
        public string name { get; set; }

    }

    public class Location
    {
        public Street street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
        public Coordinates coordinates { get; set; }
        public Timezone timezone { get; set; }
    }

    public class Login
    {
        public string uuid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string sha256 { get; set; }
    }

    public class Dob
    {
        public DateTime date { get; set; }
        public int age { get; set; }
    }

    public class Registered
    {
        public DateTime date { get; set; }
        public int age { get; set; }
    }


    public class Picture
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }
    }

    public class Result
    {
        public string gender { get; set; }
        public Name name { get; set; }
        public Location location { get; set; }
        public string email { get; set; }
        public Login login { get; set; }
        public Dob dob { get; set; }
        public Registered registered { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
        public Picture picture { get; set; }
        public string nat { get; set; }
    }

    public class Info
    {
        public string seed { get; set; }
        public int results { get; set; }
        public int page { get; set; }
        public string version { get; set; }
    }

    public class RootObject
    {
        public List<Result> results { get; set; }
        public Info info { get; set; }
    }

    #endregion
}
