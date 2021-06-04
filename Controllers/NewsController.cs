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
    public class NewsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        

        public NewsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            List<News> news = _context.News.ToList();
            news.Reverse();
            return news;
        }

        [HttpGet("/api/main_news")]
        public async Task<ActionResult<IEnumerable<News>>> GetSomeNews()
        {
            List<News> news = _context.News.ToList();
            news.Reverse();
            List<News> n = new List<News>();
            for(int i = 0; i < 8; i++)
            {
                n.Add(news.ElementAt(i));
            }
            return n;
        }

        [HttpGet("/api/searchNews/{name}")]
        public async Task<ActionResult<News>> SearchNews(string name)
        {
            var news = from s in _context.News select s;
            news = news.Where(n => n.title.Contains(name));
            
            return Ok(news);
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(long id)
        {
            var news = await _context.News.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        // PUT: api/News/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews(long id, News news)
        {
            if (id != news.id)
            {
                return BadRequest();
            }

            _context.Entry(news).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
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

        // POST: api/News
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<News>> PostNews([FromBody] News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNews", new { id = news.id }, news);
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(long id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewsExists(long id)
        {
            return _context.News.Any(e => e.id == id);
        }
    }
}
