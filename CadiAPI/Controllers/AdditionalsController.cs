using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadiAPI.Models;
using CadiAPI.Models.Context;

namespace CadiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalsController : ControllerBase
    {
        private readonly CadiContext _context;

        public AdditionalsController(CadiContext context)
        {
            _context = context;
        }

        // GET: api/Additionals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Additional>>> GetAdditionals()
        {
            return await _context.Additionals.ToListAsync();
        }

        // GET: api/Additionals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<object>>> GetAdditional(int id)
        {
            var additional = _context.Additionals.SelectMany(e => e.AdditionalProducts, (e, s) =>
            new { e.Description, s }).Where(e => e.s.ProductId == id);

            return await additional.ToListAsync();
        }

        // PUT: api/Additionals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdditional(int id, Additional additional)
        {
            if (id != additional.Id)
            {
                return BadRequest();
            }

            _context.Entry(additional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdditionalExists(id))
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

        // POST: api/Additionals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Additional>> PostAdditional(Additional additional)
        {
            _context.Additionals.Add(additional);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdditional", new { id = additional.Id }, additional);
        }

        // DELETE: api/Additionals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Additional>> DeleteAdditional(int id)
        {
            var additional = await _context.Additionals.FindAsync(id);
            if (additional == null)
            {
                return NotFound();
            }

            _context.Additionals.Remove(additional);
            await _context.SaveChangesAsync();

            return additional;
        }

        private bool AdditionalExists(int id)
        {
            return _context.Additionals.Any(e => e.Id == id);
        }
    }
}
