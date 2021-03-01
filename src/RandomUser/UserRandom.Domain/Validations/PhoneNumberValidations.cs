using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UserRandom.Domain.Entities;
using UserRandom.Domain.Entities.ValueObjects;

namespace UserRandom.Domain.Validations
{
    public class PhoneNumberValidations : AbstractValidator<PhoneNumber>
    {
        public PhoneNumberValidations()
        {
            RuleFor(x => x.Number)
              .NotNull().WithMessage("Number of trainings can't be empty.")
              .Must(x => x.Length <= 0).WithMessage("Number of trainings must be greater than 0.")
              .Must(x => x.Length > 9).WithMessage($"Phone numbers must have length");
        }
    }
}

