using System;
using System.Collections.Generic;

namespace ProjectPRN221.Models
{
    public partial class Input
    {
        public Input()
        {
            InputInfos = new HashSet<InputInfo>();
        }

        public string Id { get; set; } = null!;
        public DateTime? DateInput { get; set; }

        public virtual ICollection<InputInfo> InputInfos { get; set; }
    }
}
