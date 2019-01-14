using System;
using System.Collections.Generic;

namespace laundry_svc.Models
{
    public partial class UnitType
    {
        public UnitType()
        {
            Unit = new HashSet<Unit>();
        }

        public int UnitTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Unit> Unit { get; set; }
    }
}
