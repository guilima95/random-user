using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UserRandom.Domain.Entities.ValueObjects;

namespace UserRandom.Domain.Validations
{


    public class EmailValidations : AbstractValidator<Email>
    {
        public EmailValidations()
        {
            RuleFor(x => x.EmailAddress)
                    .NotEmpty()
                    .WithMessage("Email should not be empty.");

            RuleFor(x => x.EmailAddress)
                    .EmailAddress()
                    .WithMessage("Email should not be empty.");


        }
    }
}