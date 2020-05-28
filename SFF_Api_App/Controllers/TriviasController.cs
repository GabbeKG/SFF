using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFF_Api_App.DB;
using SFF_Api_App.Models;

namespace SFF_Api_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriviasController : ControllerBase
    {
        private readonly SFF_DbContext _context;

        public TriviasController(SFF_DbContext context)
        {
            _context = context;
        }

        // GET: api/Trivias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trivias>>> GetTrivias()
        {
            return await _context.Trivias.ToListAsync();
        }

        // GET: api/Trivias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trivias>> GetTrivias(int id)
        {
            var trivias = await _context.Trivias.FindAsync(id);

            if (trivias == null)
            {
                return NotFound();
            }

            return trivias;
        }

        // PUT: api/Trivias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrivias(int id, Trivias trivias)
        {
            if (id != trivias.Id)
            {
                return BadRequest();
            }

            _context.Entry(trivias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TriviasExists(id))
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

        // POST: api/Trivias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Trivias>> PostTrivias(Trivias trivias)
        {
            _context.Trivias.Add(trivias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrivias", new { id = trivias.Id }, trivias);
        }

        // DELETE: api/Trivias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trivias>> DeleteTrivias(int id)
        {
            var trivias = await _context.Trivias.FindAsync(id);
            if (trivias == null)
            {
                return NotFound();
            }

            _context.Trivias.Remove(trivias);
            await _context.SaveChangesAsync();

            return trivias;
        }

        private bool TriviasExists(int id)
        {
            return _context.Trivias.Any(e => e.Id == id);
        }
    }
}
