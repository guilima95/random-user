using System;
using System.Collections.Generic;
using System.Text;
using UserRandom.Domain.Entities.Base;
using UserRandom.Domain.Validations;

namespace UserRandom.Domain.Entities.ValueObjects
{
    public sealed class Name : Document
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; private set; }

        public Name(string title, string firstName, string lastName)
        {
            //Validate(this, new NameValidations());

            Title = title;
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{title}. {firstName} {LastName}";
        }

        public override string ToString()
        {
            return FullName;
        }

        public static implicit operator string(Name name)
        {
            return name.FullName;
        }
    }
}