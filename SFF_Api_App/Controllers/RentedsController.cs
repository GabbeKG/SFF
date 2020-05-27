using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using SFF_Api_App.DB;
using SFF_Api_App.Models;
using System.Xml.Linq;

namespace SFF_Api_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedsController : ControllerBase
    {
        private readonly SFF_DbContext _context;

        public RentedsController(SFF_DbContext context)
        {
            _context = context;
        }

        // GET: api/Renteds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rented>>> GetRented()
        {
            return await _context.Rented.ToListAsync();
        }

        // GET: api/Renteds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rented>> GetRented(int id)
        {
            var rented = await _context.Rented.FindAsync(id);

            if (rented == null)
            {
                return NotFound();
            }

            return rented;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIsRented(int id, bool rented, Rented rent)
        {
            if (id != rent.Id)
            {
                return BadRequest();
            }
            _context.Entry(rent).State = EntityState.Modified;
            _context.Entry(rented).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentedExists(id))
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

        // PUT: api/Renteds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRented(int id, Rented rented)
        {
            if (id != rented.Id)
            {
                return BadRequest();
            }

            _context.Entry(rented).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentedExists(id))
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

        // POST: api/Renteds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rented>> PostRented(Rented rented)
        {
            var amountRented = (from a in _context.Rented
                                select rented.movie).Count();
            if (amountRented < rented.movie.Stock)
            {
            _context.Rented.Add(rented);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRented", new { id = rented.Id }, rented);

            }
            else
            {
                return NoContent();
            }

        }

        // DELETE: api/Renteds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rented>> DeleteRented(int id)
        {
            var rented = await _context.Rented.FindAsync(id);
            if (rented == null)
            {
                return NotFound();
            }

            _context.Rented.Remove(rented);
            await _context.SaveChangesAsync();

            return rented;
        }

        private bool RentedExists(int id)
        {
            return _context.Rented.Any(e => e.Id == id);
        }
    }
}
