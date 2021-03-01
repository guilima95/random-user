using FluentValidation;
using UserRandom.Domain.Entities;
using UserRandom.Domain.Entities.ValueObjects;

namespace UserRandom.Domain.Validations
{
    public class ImageValidations : AbstractValidator<Image>
    {
        public ImageValidations()
        {
            RuleFor(a => a.Thumbnail)
                .Length(0).WithMessage("Image link is empty!");
        }
    }
}
