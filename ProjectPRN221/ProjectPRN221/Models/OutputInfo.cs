﻿using System;
using System.Collections.Generic;

namespace ProjectPRN221.Models
{
    public partial class OutputInfo
    {
        public string Id { get; set; } = null!;
        public string IdObject { get; set; } = null!;
        public string IdInputInfo { get; set; } = null!;
        public int IdCustomer { get; set; }
        public int? Counts { get; set; }
        public string? Status { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; } = null!;
        public virtual InputInfo IdInputInfoNavigation { get; set; } = null!;
        public virtual Object IdObjectNavigation { get; set; } = null!;
    }
}
