using System;
using System.Collections.Generic;
using System.Text;

namespace UserRandom.Domain.Entities.ValueObjects
{
    public class Timezone
    {
        public string Offset { get; set; }
        public string Description { get; set; }
    }
}
