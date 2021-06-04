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
    public class SongsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SongsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Songs>>> GetSongs()
        {
            var genres = await _context.Genres.ToListAsync();
            var artist = await _context.Artists.ToListAsync();
            return await _context.Songs.ToListAsync();
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Songs>> GetSongs(long id)
        {
            var genres = await _context.Genres.ToListAsync();
            var artist = await _context.Artists.ToListAsync();
            var songs = await _context.Songs.FindAsync(id);

            if (songs == null)
            {
                return NotFound();
            }

            return songs;
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongs(long id, Songs songs)
        {
            if (id != songs.id)
            {
                return BadRequest();
            }
            var g = _context.Genres.Find(songs.genre.id);
            var a = _context.Artists.Find(songs.artist.id);
            songs.genre = g;
            songs.artist = a;
            _context.Entry(songs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongsExists(id))
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

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Songs>> PostSongs(Songs songs)
        {
            var g = _context.Genres.Find(songs.genre.id);
            var a = _context.Artists.Find(songs.artist.id);
            songs.genre = g;
            songs.artist = a;
            _context.Songs.Add(songs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongs", new { id = songs.id }, songs);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongs(long id)
        {
            var songs = await _context.Songs.FindAsync(id);
            if (songs == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(songs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongsExists(long id)
        {
            return _context.Songs.Any(e => e.id == id);
        }
    }
}
