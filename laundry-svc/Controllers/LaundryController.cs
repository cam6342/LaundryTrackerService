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

        [HttpPost]
        [Route("Cycle")]     
        public ActionResult<int> Cycle(int unitId)
        {
            var lr = new LaundryRepository(_context);
            return lr.StartCycle(unitId);
        }

        [HttpPut]
        [Route("Cycle")]
        public ActionResult<int> CycleEnd(int unitId)
        {
            var lr = new LaundryRepository(_context);
            return lr.EndCycle(unitId);
        }

        [HttpGet]
        [Route("UnitType")]
        public ActionResult<List<UnitType>> UnitType()
        {
            var lr = new LaundryRepository(_context);

            return lr.GetAllUnitTypes();
        }

        [HttpPost]
        [Route("Unit")]
        public ActionResult<int> CreateUnit(Unit unit)
        {
            var lr = new LaundryRepository(_context);
            return lr.CreateUnit(unit);
        }

        [HttpGet]
        [Route("Cycle")]
        public ActionResult<List<LaundryRuns>> GetAllCycles()
        {
            var lr = new LaundryRepository(_context);
            return lr.GetAllLaundryRuns();
        }

        [HttpGet]
        [Route("Cycle/{laundryRunId}")]
        public ActionResult<LaundryRuns> GetCycle(int laundryRunId)
        {
            var lr = new LaundryRepository(_context);
            return lr.GetLaundryRun(laundryRunId);
        }

        [HttpGet]
        [Route("Cycle/{laundryRunId}/Status")]
        public ActionResult<LaundryStatus> GetCycleStatus(int laundryRunId)
        {
            var lr = new LaundryRepository(_context);
            return lr.GetLaundryRunStatusByLaundryRunId(laundryRunId);
        }

        [HttpGet]
        [Route("Unit/{unitId}/Status")]
        public ActionResult<LaundryStatus> GetUnitStatus(int unitId)
        {
            var lr = new LaundryRepository(_context);
            return lr.GetUnitStatus(unitId);
        }
    }
}
