using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using laundry_svc.Models;
using Microsoft.AspNetCore.Mvc;

namespace laundry_svc
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaundryController : ControllerBase
    {
        private readonly LaundryDBContext _context;

        public LaundryController(LaundryDBContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return LaundryRepository.GetValues();
        }

        [HttpPost]
        [Route("Cycle")]
        public ActionResult<int> Cycle(int? unitNumber)
        {
            LaundryRepository lr = new LaundryRepository(_context);

            return 1;
        }

        [HttpGet]
        [Route("UnitType")]
        public ActionResult<List<UnitType>> UnitType()
        {
            LaundryRepository lr = new LaundryRepository(_context);

            return lr.GetAllUnitTypes();
        }
    }
}
