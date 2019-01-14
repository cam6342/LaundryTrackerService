using System;
using System.Collections.Generic;

namespace laundry_svc.Models
{
    public partial class SupplyType
    {
        public SupplyType()
        {
            Supplies = new HashSet<Supplies>();
        }

        public int SupplyTypeId { get; set; }
        public string Name { get; set; }
        public int MaxAmount { get; set; }

        public virtual ICollection<Supplies> Supplies { get; set; }
    }
}
