using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UserRandom.Domain.Entities;
using UserRandom.Domain.Entities.ValueObjects;

namespace UserRandom.Domain.Validations
{
    public class NameValidations : AbstractValidator<Name>
    {
        public NameValidations()
        {
            RuleFor(x => x.FirstName)
                  .NotEmpty()
                  .WithName("first name empty.");
        }
    }
}
