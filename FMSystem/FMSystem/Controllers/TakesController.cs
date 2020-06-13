using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FMSystem.Entity.fms;
using FMSystem.Models;

namespace FMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakesController : ControllerBase
    {
        private readonly fmsContext _context;

        public TakesController(fmsContext context)
        {
            _context = context;
        }

        // GET: api/Takes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Take>>> GetTakes()
        {
            return await _context.Takes.ToListAsync();
        }

        // GET: api/Takes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Take>> GetTake(int id)
        {
            var take = await _context.Takes.FindAsync(id);

            if (take == null)
            {
                return NotFound();
            }

            return take;
        }

        // PUT: api/Takes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTake(int id, Take take)
        {
            if (id != take.Id)
            {
                return BadRequest();
            }

            _context.Entry(take).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakeExists(id))
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

        // POST: api/Takes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Take>> PostTake(Take take)
        {
            _context.Takes.Add(take);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTake", new { id = take.Id }, take);
        }

        // DELETE: api/Takes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Take>> DeleteTake(int id)
        {
            var take = await _context.Takes.FindAsync(id);
            if (take == null)
            {
                return NotFound();
            }

            _context.Takes.Remove(take);
            await _context.SaveChangesAsync();

            return take;
        }

        public async Task<ActionResult<List<Take>>> SearchBySectionId(int id)
        {
            var takes = await _context.Takes.Where(t => t.SectionId == id).ToListAsync();

            return takes;
        }

        public async Task<ActionResult<List<Take>>> SearchByMemberId(int id)
        {
            var takes = await _context.Takes.Where(t => t.MemberId == id).ToListAsync();

            return takes;
        }
        private bool TakeExists(int id)
        {
            return _context.Takes.Any(e => e.Id == id);
        }
    }
}
