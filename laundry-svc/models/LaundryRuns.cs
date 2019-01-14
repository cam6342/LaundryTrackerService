using System;
using System.Collections.Generic;

namespace laundry_svc.Models
{
    public partial class LaundryRuns
    {
        public int LaundryRunId { get; set; }
        public int UnitId { get; set; }
        public DateTime RunStart { get; set; }
        public DateTime? RunEnd { get; set; }
        public int? Duration { get; set; }
        public int Status { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
