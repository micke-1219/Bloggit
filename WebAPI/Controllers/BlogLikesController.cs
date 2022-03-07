using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DbContexts;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogLikesController : ControllerBase
    {
        private readonly BloggitDbContext _context;

        public BlogLikesController(BloggitDbContext context)
        {
            _context = context;
        }

        // GET: api/BlogLikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogLike>>> GetBlogLikes()
        {
            return await _context.BlogLikes.ToListAsync();
        }

        // GET: api/BlogLikes/Blog/5
        [HttpGet("Blog/{blogId}")]
        public async Task<ActionResult<IEnumerable<BlogLike>>> GetBlogBlogLikes(int blogId)
        {
            return await _context.BlogLikes.Where(x => x.BlogId == blogId).ToListAsync();
        }

        // GET: api/BlogLikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogLike>> GetBlogLike(int id)
        {
            var blogLike = await _context.BlogLikes.FindAsync(id);

            if (blogLike == null)
            {
                return NotFound();
            }

            return blogLike;
        }

        // PUT: api/BlogLikes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogLike(int id, BlogLike blogLike)
        {
            if (id != blogLike.Id)
            {
                return BadRequest();
            }

            _context.Entry(blogLike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogLikeExists(id))
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

        // POST: api/BlogLikes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogLike>> PostBlogLike(BlogLike blogLike)
        {
            _context.BlogLikes.Add(blogLike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogLike", new { id = blogLike.Id }, blogLike);
        }

        // DELETE: api/BlogLikes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogLike(int id)
        {
            var blogLike = await _context.BlogLikes.FindAsync(id);
            if (blogLike == null)
            {
                return NotFound();
            }

            _context.BlogLikes.Remove(blogLike);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogLikeExists(int id)
        {
            return _context.BlogLikes.Any(e => e.Id == id);
        }
    }
}
