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
    public class MemberLevelsController : ControllerBase
    {
        private readonly DataContext _context;

        public MemberLevelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MemberLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberLevel>>> GetMemberLevel()
        {
            return await _context.MemberLevel.ToListAsync();
        }

        // GET: api/MemberLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberLevel>> GetMemberLevel(int id)
        {
            var memberLevel = await _context.MemberLevel.FindAsync(id);

            if (memberLevel == null)
            {
                return NotFound();
            }

            return memberLevel;
        }

        // PUT: api/MemberLevels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberLevel(int id, MemberLevel memberLevel)
        {
            if (id != memberLevel.MemberLevelId)
            {
                return BadRequest();
            }

            _context.Entry(memberLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberLevelExists(id))
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

        // POST: api/MemberLevels
        [HttpPost]
        public async Task<ActionResult<MemberLevel>> PostMemberLevel(MemberLevel memberLevel)
        {
            _context.MemberLevel.Add(memberLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemberLevel", new { id = memberLevel.MemberLevelId }, memberLevel);
        }

        // DELETE: api/MemberLevels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MemberLevel>> DeleteMemberLevel(int id)
        {
            var memberLevel = await _context.MemberLevel.FindAsync(id);
            if (memberLevel == null)
            {
                return NotFound();
            }

            _context.MemberLevel.Remove(memberLevel);
            await _context.SaveChangesAsync();

            return memberLevel;
        }

        private bool MemberLevelExists(int id)
        {
            return _context.MemberLevel.Any(e => e.MemberLevelId == id);
        }
    }
}
