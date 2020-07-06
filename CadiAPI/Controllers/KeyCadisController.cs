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
    public class KeyCadisController : ControllerBase
    {
        private readonly CadiContext _context;

        public KeyCadisController(CadiContext context)
        {
            _context = context;
        }

        // GET: api/KeyCadis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KeyCadi>>> GetKeyCadis()
        {
            return await _context.KeyCadis.ToListAsync();
        }

        // GET: api/KeyCadis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KeyCadi>> GetKeyCadi(int id)
        {
            var keyCadi = await _context.KeyCadis.FindAsync(id);

            if (keyCadi == null)
            {
                return NotFound();
            }

            return keyCadi;
        }

        // PUT: api/KeyCadis/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeyCadi(int id, KeyCadi keyCadi)
        {
            if (id != keyCadi.Id)
            {
                return BadRequest();
            }

            _context.Entry(keyCadi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyCadiExists(id))
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

        // POST: api/KeyCadis
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<KeyCadi>> PostKeyCadi(KeyCadi keyCadi)
        {
            _context.KeyCadis.Add(keyCadi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKeyCadi", new { id = keyCadi.Id }, keyCadi);
        }

        // DELETE: api/KeyCadis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KeyCadi>> DeleteKeyCadi(int id)
        {
            var keyCadi = await _context.KeyCadis.FindAsync(id);
            if (keyCadi == null)
            {
                return NotFound();
            }

            _context.KeyCadis.Remove(keyCadi);
            await _context.SaveChangesAsync();

            return keyCadi;
        }

        private bool KeyCadiExists(int id)
        {
            return _context.KeyCadis.Any(e => e.Id == id);
        }
    }
}
