using System;
using System.Collections.Generic;
using System.Text;
using UserRandom.CrossCutting.Attributes;
using UserRandom.Domain.Entities.Base;
using UserRandom.Domain.Validations;

namespace UserRandom.Domain.Entities
{
    [BsonCollection("phone")]
    public sealed class PhoneNumber : Document
    {

        public string Number { get; set; }

        public PhoneNumber(string number)
        {
            Validate(this, new PhoneNumberValidations());

            Number = number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }

        public static implicit operator string(PhoneNumber number)
        {
            return number.Number;
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }


            return ((PhoneNumber)obj).Number == Number;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}