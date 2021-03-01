using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using UserRandom.CrossCutting.Attributes;
using UserRandom.Domain.Entities.Base;
using UserRandom.Domain.Entities.ValueObjects;
using UserRandom.Domain.Enums;

namespace UserRandom.Domain.Entities
{
    [BsonCollection("user")]
    public sealed class User : Document
    {
        public User()
        {

        }

        public string Gender { get; set; }
        public Name Name { get; set; }
        public Location Location { get; set; }
        public Email Email { get; set; }
        public Login Login { get; set; }
        public Dob Dob { get; set; }
        public Registered Registered { get; set; }
        public PhoneNumber Phone { get; set; }
        public string Cell { get; set; }
        public Image Picture { get; set; }
        public string Nat { get; set; }
        public DateTime Imported_t { get; set; }
        public RandomStatus Status { get; set; }


        public User(Name name, Dob dob, PhoneNumber number, Email email, Image image)
        {

            Name = name;
            Dob = dob;
            Phone = number;
            Email = email;
            Picture = image;
        }


    }
}