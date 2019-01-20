using laundry_svc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace laundry_svc
{
    public class LaundryRepository
    {
        private readonly LaundryDBContext _context;

        public LaundryRepository(LaundryDBContext context)
        {
            _context = context;
        }

        public int StartCycle(int unitId)
        {
            try
            {
                var foundUnit = _context.Unit
                                    .Where(u => u.UnitId == unitId)
                                    .Select(u => new Unit
                                    {
                                        UnitId = u.UnitId
                                    }).FirstOrDefault();

                if (foundUnit == null)
                {
                    var rnd = new Random();
                    var newUnitID = rnd.Next();
                    CreateUnit(new Unit
                    {
                        UnitId = newUnitID,
                        Name = "Unknown",
                        UnitTypeId = LaundryConstants.MachineTypes.UNKNOWN
                    });

                    foundUnit = _context.Unit
                                    .Where(u => u.UnitId == newUnitID)
                                    .Select(u => new Unit
                                    {
                                        UnitId = u.UnitId
                                    }).FirstOrDefault();
                }

                //Check and close any currently "wrongly" running item
                var existingRuns = _context.LaundryRuns
                     .Where(lr => lr.UnitId == foundUnit.UnitId).ToList();

                foreach (LaundryRuns runs in existingRuns)
                {
                    runs.LaundryStatusId = LaundryConstants.LaundryStatus.STOPPED;
                }

                //Add new running item
                _context.LaundryRuns.Add(new LaundryRuns
                {
                    RunStart = DateTime.UtcNow,
                    UnitId = foundUnit.UnitId,
                    LaundryStatusId = LaundryConstants.LaundryStatus.RUNNING
                });

                _context.SaveChanges();

                return foundUnit.UnitId;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public List<UnitType> GetAllUnitTypes()
        {
            return _context.UnitType.ToList();
        }

        public int CreateUnit(Unit unit)
        {
            try
            {
                _context.Unit.Add(unit);
                _context.SaveChanges();
                return unit.UnitId;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public List<LaundryRuns> GetAllLaundryRuns()
        {
            return _context.LaundryRuns.ToList();
        }

        public LaundryRuns GetLaundryRun(int laundryRunId)
        {
            return _context.LaundryRuns
                .Where(lr => lr.LaundryRunId == laundryRunId).SingleOrDefault();
        }

        public LaundryStatus GetLaundryRunStatusByLaundryRunId(int laundryRunId)
        {
            return _context.LaundryRuns
                .Where(lr => lr.LaundryRunId == laundryRunId)
                .Include(lr => lr.LaundryStatus)
                .Select(lr => new LaundryStatus
                {
                    LaundryStatusId = lr.LaundryStatus.LaundryStatusId,
                    Status = lr.LaundryStatus.Status
                }).SingleOrDefault();

        }

        public LaundryStatus GetUnitStatus(int unitId)
        {
            return _context.LaundryRuns
                .Where(lr => lr.UnitId == unitId)
                .OrderByDescending(lr => lr.RunStart)
                .Include(lr => lr.LaundryStatus)
                .Select(lr => new LaundryStatus
                {
                    LaundryStatusId = lr.LaundryStatus.LaundryStatusId,
                    Status = lr.LaundryStatus.Status
                }).FirstOrDefault();

        }

        public int EndCycle(int unitId)
        {
            //Find running cycle
            var runs = _context.LaundryRuns
                 .Where(lr => lr.UnitId == unitId)
                 .Where(lr => lr.LaundryStatusId == LaundryConstants.LaundryStatus.RUNNING)
                 .ToList();

            foreach (LaundryRuns run in runs)
            {
                run.LaundryStatusId = LaundryConstants.LaundryStatus.STOPPED;
                run.RunEnd = DateTime.UtcNow;
                run.DurationInSeconds = (int)Math.Round(((TimeSpan)(run.RunEnd - run.RunStart)).TotalSeconds);
            }

            return _context.SaveChanges();
        }
    }
}
