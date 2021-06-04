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
    public class ArticlesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ArticlesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articles>>> GetArticles()
        {
            List<Users> users = await _context.Users.ToListAsync();
            List<Articles> a = await _context.Articles.ToListAsync();
            a.Reverse();
            return a;
        }

        [HttpGet("/api/main_articles")]
        public async Task<ActionResult<IEnumerable<Articles>>> GetSomeNews()
        {
            List<Articles> articles= _context.Articles.ToList();
            articles.Reverse();
            List<Articles> n = new List<Articles>();
            for (int i = 0; i<4; i++)
            {
                n.Add(articles.ElementAt(i));
            }
            return n;
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articles>> GetArticles(long id)
        {
            var users = await _context.Users.ToListAsync();
            var articles = await _context.Articles.FindAsync(id);

            if (articles == null)
            {
                return NotFound();
            }

            return articles;
        }

        // PUT: api/Articles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticles(long id, Articles articles)
        {
            if (id != articles.id)
            {
                return BadRequest();
            }

            var u = _context.Users.Find(articles.users.id);
            //articles.users = u;
            Articles a = articles;
            a.users = u;

            _context.Entry(a).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticlesExists(id))
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

        // POST: api/Articles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Articles>> PostArticles(Articles articles)
        {
            Users u = _context.Users.Find(articles.users.id);
            articles.users = u;
            _context.Articles.Add(articles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticles", new { id = articles.id }, articles);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticles(long id)
        {
            var articles = await _context.Articles.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(articles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticlesExists(long id)
        {
            return _context.Articles.Any(e => e.id == id);
        }
    }
}
