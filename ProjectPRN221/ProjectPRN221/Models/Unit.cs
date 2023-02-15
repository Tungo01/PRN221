using System;
using System.Collections.Generic;

namespace ProjectPRN221.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Objects = new HashSet<Object>();
        }

        public int Id { get; set; }
        public string? DisplayName { get; set; }

        public virtual ICollection<Object> Objects { get; set; }
    }
}
