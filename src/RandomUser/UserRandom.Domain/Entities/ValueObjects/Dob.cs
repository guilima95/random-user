﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UserRandom.Domain.Entities.ValueObjects
{
    public class Dob
    {
        public DateTime Date { get; set; }
        public int Age { get; set; }
    }
}
