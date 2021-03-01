using System;
using System.Collections.Generic;
using System.Text;

namespace UserRandom.Domain.Entities.ValueObjects
{
    public class Info
    {
        public string Seed { get; set; }
        public int Results { get; set; }
        public int Page { get; set; }
        public string Version { get; set; }
    }
}
