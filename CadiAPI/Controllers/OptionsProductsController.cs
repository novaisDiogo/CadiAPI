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
    public class OptionsProductsController : ControllerBase
    {
        private readonly CadiContext _context;

        public OptionsProductsController(CadiContext context)
        {
            _context = context;
        }

        // GET: api/OptionsProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionsProduct>>> GetOptionsProducts()
        {
            return await _context.OptionsProducts.ToListAsync();
        }

        // GET: api/OptionsProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetOptionsProduct(int id)
        {
            var test = _context.Products.SelectMany(e => e.OptionsProducts, (e, s) =>
            new
            {
                e.Id,
                e.Name,
                e.Description,
                e.Image,
                e.Status,
                e.UnitId
            ,
                s
            }).Where(e => e.s.OptionsId == id);

            return await test.ToListAsync();
        }

        // PUT: api/OptionsProducts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOptionsProduct(int id, OptionsProduct optionsProduct)
        {
            if (id != optionsProduct.OptionsId)
            {
                return BadRequest();
            }

            _context.Entry(optionsProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionsProductExists(id))
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

        // POST: api/OptionsProducts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OptionsProduct>> PostOptionsProduct(OptionsProduct optionsProduct)
        {
            _context.OptionsProducts.Add(optionsProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OptionsProductExists(optionsProduct.OptionsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOptionsProduct", new { id = optionsProduct.OptionsId }, optionsProduct);
        }

        // DELETE: api/OptionsProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OptionsProduct>> DeleteOptionsProduct(int id)
        {
            var optionsProduct = await _context.OptionsProducts.FindAsync(id);
            if (optionsProduct == null)
            {
                return NotFound();
            }

            _context.OptionsProducts.Remove(optionsProduct);
            await _context.SaveChangesAsync();

            return optionsProduct;
        }

        private bool OptionsProductExists(int id)
        {
            return _context.OptionsProducts.Any(e => e.OptionsId == id);
        }
    }
}
