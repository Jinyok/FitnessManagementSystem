using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FMSystem.Models;

namespace FMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private readonly fmsContext _context;

        public CoachesController(fmsContext context)
        {
            _context = context;
        }

        // GET: api/Coaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> GetCoach()
        {
            return await _context.Coach.ToListAsync();
        }

        // GET: api/Coaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coach>> GetCoach(int id)
        {
            var coach = await _context.Coach.FindAsync(id);

            if (coach == null)
            {
                return NotFound();
            }

            return coach;
        }

        // PUT: api/Coaches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoach(int id, Coach coach)
        {
            if (id != coach.CoachId)
            {
                return BadRequest();
            }

            _context.Entry(coach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachExists(id))
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

        // POST: api/Coaches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Coach>> PostCoach(Coach coach)
        {
            _context.Coach.Add(coach);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoach", new { id = coach.CoachId }, coach);
        }

        // DELETE: api/Coaches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Coach>> DeleteCoach(int id)
        {
            var coach = await _context.Coach.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }

            _context.Coach.Remove(coach);
            await _context.SaveChangesAsync();

            return coach;
        }
        
                public async Task<ActionResult<List<Coach>>> SearchById(int id)
        {
            var coaches = await _context.Coach.Where(c => c.CoachId == id).ToListAsync();
            
            return coaches;
        }

        public async Task<ActionResult<List<Coach>>> SearchByName(string name)
        {
            var coaches = await _context.Coach.Where(c => c.Name == name).ToListAsync();

            return coaches;
        }

        private bool CoachExists(int id)
        {
            return _context.Coach.Any(e => e.CoachId == id);
        }
    }
}
