using System;
using System.Collections.Generic;

namespace ProjectPRN221.Models
{
    public partial class Output
    {
        public string Id { get; set; } = null!;
        public DateTime? DateOutput { get; set; }

        public virtual OutputInfo? OutputInfo { get; set; }
    }
}
