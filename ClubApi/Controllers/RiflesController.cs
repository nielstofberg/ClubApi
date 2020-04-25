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
    public class RiflesController : ControllerBase
    {
        private readonly DataContext _context;

        public RiflesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Rifles?ownerId=5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rifle>>> GetRifle(long? ownerId)
        {
            if (ownerId != null)
            {
                return await _context.Rifle.Where(r => r.OwnerMemberId == ownerId).ToListAsync();
            }
            return await _context.Rifle.ToListAsync();
        }

        // GET: api/Rifles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rifle>> GetRifle(long id)
        {
            var rifle = await _context.Rifle.FindAsync(id);

            if (rifle == null)
            {
                return NotFound();
            }

            return rifle;
        }

        // PUT: api/Rifles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRifle(long id, Rifle rifle)
        {
            if (id != rifle.RifleId)
            {
                return BadRequest();
            }

            _context.Entry(rifle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RifleExists(id))
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

        // POST: api/Rifles
        [HttpPost]
        public async Task<ActionResult<Rifle>> PostRifle(Rifle rifle)
        {
            _context.Rifle.Add(rifle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRifle", new { id = rifle.RifleId }, rifle);
        }

        // DELETE: api/Rifles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rifle>> DeleteRifle(long id)
        {
            var rifle = await _context.Rifle.FindAsync(id);
            if (rifle == null)
            {
                return NotFound();
            }

            _context.Rifle.Remove(rifle);
            await _context.SaveChangesAsync();

            return rifle;
        }

        private bool RifleExists(long id)
        {
            return _context.Rifle.Any(e => e.RifleId == id);
        }
    }
}
