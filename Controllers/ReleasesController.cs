using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musicpolitan.Database;
using Musicpolitan.Models;

namespace Musicpolitan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReleasesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ReleasesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Releases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Releases>>> GetReleases()
        {
            return await _context.Releases.ToListAsync();
        }

        // GET: api/Releases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Releases>> GetReleases(long id)
        {
            var releases = await _context.Releases.FindAsync(id);

            if (releases == null)
            {
                return NotFound();
            }

            return releases;
        }

        // PUT: api/Releases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReleases(long id, Releases releases)
        {
            if (id != releases.Id)
            {
                return BadRequest();
            }

            _context.Entry(releases).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReleasesExists(id))
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

        // POST: api/Releases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Releases>> PostReleases(Releases releases)
        {
            _context.Releases.Add(releases);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReleases", new { id = releases.Id }, releases);
        }

        // DELETE: api/Releases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReleases(long id)
        {
            var releases = await _context.Releases.FindAsync(id);
            if (releases == null)
            {
                return NotFound();
            }

            _context.Releases.Remove(releases);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReleasesExists(long id)
        {
            return _context.Releases.Any(e => e.Id == id);
        }
    }
}
