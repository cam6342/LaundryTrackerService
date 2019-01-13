using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laundry_svc
{
    public class LaundryRepository
    {
        public static ActionResult<IEnumerable<string>> GetValues() { 
            return new string[] { "value1", "value2" }; 
        }
    }
}
