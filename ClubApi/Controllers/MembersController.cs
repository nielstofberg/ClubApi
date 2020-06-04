using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClubApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly DataContext _context;

        public MembersController(DataContext context)
        {
            _context = context;
            // Creates the database if not exists
            context.Database.EnsureCreated();
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMember(int? number, bool? detailed=true )
        {
            if (number != null)
            {
                try
                {
                    // similar to GET: api/Members/5 but searches by member number (not id) and returns a Member array
                    return await _context.Member
                        .Include(m => m.MemberType)
                        .Include(m => m.MemberLevel)
                        .Include(m => m.Rifles)
                        .Include(m => m.Facs)
                        .Include(m => m.Lockers)
                        .Where(m => m.MemberNo == number).ToListAsync();
                }
                catch
                {
                    return BadRequest();
                }
            }
            if (detailed == null || detailed == true)
            {
                return await _context.Member
                    .Include(m => m.MemberType)
                    .ToListAsync();
            }
            else
            {
                return await _context.Member.ToListAsync();
            }
        }

        /// <summary>
        /// This function returned incomplete JSON data, but it was fixed with info from this post:
        /// https://stackoverflow.com/questions/54633340/asp-net-core-web-api-2-2-controller-not-returning-complete-json
        /// </summary>
        // GET: api/Members/5
        [HttpGet("{id}")]
        public ActionResult<Member> GetMember(long id)
        {
            try
            {
                var member = _context.Member
                    .Include(m => m.MemberType)
                    .Include(m => m.Rifles)
                    .Single(m => m.MemberId == id);

                if (member == null)
                {
                    return NotFound();
                }
                return member;
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Members/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember([FromRoute]long id, [FromBody]Member member)
        {
            if (id != member.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(member);
        }

        // POST: api/Members
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            _context.Member.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.MemberId }, member);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(long id)
        {
            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Member.Remove(member);
            await _context.SaveChangesAsync();

            return member;
        }

        private bool MemberExists(long id)
        {
            return _context.Member.Any(e => e.MemberId == id);
        }
    }
}
