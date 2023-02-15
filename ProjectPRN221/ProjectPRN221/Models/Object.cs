using System;
using System.Collections.Generic;

namespace ProjectPRN221.Models
{
    public partial class Object
    {
        public Object()
        {
            InputInfos = new HashSet<InputInfo>();
            OutputInfos = new HashSet<OutputInfo>();
        }

        public string Id { get; set; } = null!;
        public string? DisplayName { get; set; }
        public int IdUnit { get; set; }
        public int IdSuplier { get; set; }
        public string? Qrcode { get; set; }
        public string? BarCode { get; set; }

        public virtual Suplier IdSuplierNavigation { get; set; } = null!;
        public virtual Unit IdUnitNavigation { get; set; } = null!;
        public virtual ICollection<InputInfo> InputInfos { get; set; }
        public virtual ICollection<OutputInfo> OutputInfos { get; set; }
    }
}
