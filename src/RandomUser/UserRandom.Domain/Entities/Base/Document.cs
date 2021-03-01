using FluentValidation;
using FluentValidation.Results;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

using System.Text;
using UserRandom.Domain.Entities.Base;

namespace UserRandom.Domain.Entities.Base
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;

        public ValidationResult ValidationResult { get; private set; }

        public bool Valid { get; private set; }
    
        public bool Invalid => !Valid;

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}