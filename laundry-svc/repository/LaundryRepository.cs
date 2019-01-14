using laundry_svc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laundry_svc
{
    public class LaundryRepository
    {
        private readonly LaundryDBContext _context;

        private static int UNITNUMBER;
        public LaundryRepository(LaundryDBContext context)
        {
            _context = context;
        }

        public static ActionResult<IEnumerable<string>> GetValues() { 
            return new string[] { "value1", "value2" }; 
        }

        public int StartCycle()
        {

            return 1;
        }

        public List<UnitType> GetAllUnitTypes()
        {
            return _context.UnitType.ToList();
        }
    }
}
