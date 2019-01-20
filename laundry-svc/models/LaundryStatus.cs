using System;
using System.Collections.Generic;

namespace laundry_svc.Models
{
    public partial class LaundryStatus
    {
        public LaundryStatus()
        {
            LaundryRuns = new HashSet<LaundryRuns>();
        }

        public int LaundryStatusId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<LaundryRuns> LaundryRuns { get; set; }
    }
}
