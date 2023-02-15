using System;
using System.Collections.Generic;

namespace ProjectPRN221.Models
{
    public partial class InputInfo
    {
        public InputInfo()
        {
            OutputInfos = new HashSet<OutputInfo>();
        }

        public string Id { get; set; } = null!;
        public string IdObject { get; set; } = null!;
        public string IdInput { get; set; } = null!;
        public int? Counts { get; set; }
        public double? InputPrice { get; set; }
        public double? OutputPrice { get; set; }
        public string? Status { get; set; }

        public virtual Input IdInputNavigation { get; set; } = null!;
        public virtual Object IdObjectNavigation { get; set; } = null!;
        public virtual ICollection<OutputInfo> OutputInfos { get; set; }
    }
}
