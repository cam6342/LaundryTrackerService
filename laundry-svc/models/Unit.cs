using System;
using System.Collections.Generic;

namespace laundry_svc.Models
{
    public partial class Unit
    {
        public Unit()
        {
            LaundryRuns = new HashSet<LaundryRuns>();
            Supplies = new HashSet<Supplies>();
        }

        public int UnitId { get; set; }
        public int UnitTypeId { get; set; }
        public string Name { get; set; }

        public virtual UnitType UnitType { get; set; }
        public virtual ICollection<LaundryRuns> LaundryRuns { get; set; }
        public virtual ICollection<Supplies> Supplies { get; set; }
    }
}
