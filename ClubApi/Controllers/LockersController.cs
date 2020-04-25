using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClubApi.Models;

namespace ClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockersController : ControllerBase
    {
        private readonly DataContext _context;

        public LockersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Lockers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locker>>> GetLocker()
        {
            return await _context.Locker.ToListAsync();
        }

        // GET: api/Lockers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locker>> GetLocker(int id)
        {
            var locker = await _context.Locker.FindAsync(id);

            if (locker == null)
            {
                return NotFound();
            }

            return locker;
        }

        // GET: api/Lockers/byowner/2
        [HttpGet("byowner/{id}")]
        public ActionResult<IEnumerable<Locker>> GetByOwner(long id)
        {
            var owner = _context.Member.Find(id);
            if (owner != null)
            {
                Locker[] lockers = _context.Locker.Where(l => l.Owner == owner).ToArray();

                if (lockers == null)
                {
                    return NotFound();
                }
                return lockers;
            }
            return NotFound();
        }

        // PUT: api/Lockers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocker(int id, Locker locker)
        {
            if (id != locker.LockerId)
            {
                return BadRequest();
            }

            _context.Entry(locker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LockerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Lockers
        [HttpPost]
        public async Task<ActionResult<Locker>> PostLocker(Locker locker)
        {
            _context.Locker.Add(locker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocker", new { id = locker.LockerId }, locker);
        }

        // DELETE: api/Lockers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Locker>> DeleteLocker(int id)
        {
            var locker = await _context.Locker.FindAsync(id);
            if (locker == null)
            {
                return NotFound();
            }

            _context.Locker.Remove(locker);
            await _context.SaveChangesAsync();

            return locker;
        }

        private bool LockerExists(int id)
        {
            return _context.Locker.Any(e => e.LockerId == id);
        }
    }
}
