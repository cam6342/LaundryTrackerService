using System;
using System.Collections.Generic;

namespace laundry_svc.Models
{
    public partial class Supplies
    {
        public int SupplyId { get; set; }
        public int UnitId { get; set; }
        public int SupplyTypeId { get; set; }
        public int EstimatedAmountRemaining { get; set; }

        public virtual SupplyType SupplyType { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
