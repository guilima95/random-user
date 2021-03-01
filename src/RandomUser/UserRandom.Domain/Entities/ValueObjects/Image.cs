using System;
using System.Collections.Generic;
using System.Text;
using UserRandom.Domain.Entities.Base;
using UserRandom.Domain.Validations;

namespace UserRandom.Domain.Entities.ValueObjects
{
    public sealed class Image : Document
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }

        public Image(string thumbnail)
        {
            Validate(this, new ImageValidations());

            Thumbnail = thumbnail;
            Thumbnail = thumbnail.Replace(".jpg", "--small.jpg");
        }
    }
}