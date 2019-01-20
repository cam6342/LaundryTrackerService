using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laundry_svc
{
    public static class LaundryConstants
    {
        public static class LaundryStatus {
            public const int UNKNOWN = 0;
            public const int RUNNING = 1;
            public const int STOPPED = 2;
        }

        public static class MachineTypes
        {
            public const int UNKNOWN = 0;
            public const int WASHER = 1;
            public const int DRYER = 2;
        }
    }
}
