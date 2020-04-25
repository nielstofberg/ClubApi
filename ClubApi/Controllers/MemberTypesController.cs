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
    public class MemberTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public MemberTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MemberTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberType>>> GetMemberType()
        {
            return await _context.MemberType.ToListAsync();
        }

        // GET: api/MemberTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberType>> GetMemberType(int id)
        {
            var memberType = await _context.MemberType.FindAsync(id);

            if (memberType == null)
            {
                return NotFound();
            }

            return memberType;
        }

        // PUT: api/MemberTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberType(int id, MemberType memberType)
        {
            if (id != memberType.MemberTypeId)
            {
                return BadRequest();
            }

            _context.Entry(memberType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberTypeExists(id))
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

        // POST: api/MemberTypes
        [HttpPost]
        public async Task<ActionResult<MemberType>> PostMemberType(MemberType memberType)
        {
            _context.MemberType.Add(memberType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemberType", new { id = memberType.MemberTypeId }, memberType);
        }

        // DELETE: api/MemberTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MemberType>> DeleteMemberType(int id)
        {
            var memberType = await _context.MemberType.FindAsync(id);
            if (memberType == null)
            {
                return NotFound();
            }

            _context.MemberType.Remove(memberType);
            await _context.SaveChangesAsync();

            return memberType;
        }

        private bool MemberTypeExists(int id)
        {
            return _context.MemberType.Any(e => e.MemberTypeId == id);
        }
    }
}
