using UserRandom.Domain.Entities.Base;
using UserRandom.Domain.Validations;

namespace UserRandom.Domain.Entities.ValueObjects
{
    public sealed class Email : Document
    {
        public string EmailAddress { get; set; }

        public Email(string email)
        {
            Validate(this, new EmailValidations());
        }

        public override string ToString()
        {
            return EmailAddress;
        }

        public static implicit operator string(Email email)
        {
            return email.EmailAddress;
        }
    }
}