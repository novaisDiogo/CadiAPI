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
    public class AdditionalProductsController : ControllerBase
    {
        private readonly CadiContext _context;

        public AdditionalProductsController(CadiContext context)
        {
            _context = context;
        }

        // GET: api/AdditionalProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdditionalProduct>>> GetAdditionalProducts()
        {
            return await _context.AdditionalProducts.ToListAsync();
        }

        // GET: api/AdditionalProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdditionalProduct>> GetAdditionalProduct(int id)
        {
            var additionalProduct = await _context.AdditionalProducts.FindAsync(id);

            if (additionalProduct == null)
            {
                return NotFound();
            }

            return additionalProduct;
        }

        // PUT: api/AdditionalProducts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdditionalProduct(int id, AdditionalProduct additionalProduct)
        {
            if (id != additionalProduct.AdditionalId)
            {
                return BadRequest();
            }

            _context.Entry(additionalProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdditionalProductExists(id))
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

        // POST: api/AdditionalProducts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AdditionalProduct>> PostAdditionalProduct(AdditionalProduct additionalProduct)
        {
            _context.AdditionalProducts.Add(additionalProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdditionalProductExists(additionalProduct.AdditionalId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdditionalProduct", new { id = additionalProduct.AdditionalId }, additionalProduct);
        }

        // DELETE: api/AdditionalProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdditionalProduct>> DeleteAdditionalProduct(int id)
        {
            var additionalProduct = await _context.AdditionalProducts.FindAsync(id);
            if (additionalProduct == null)
            {
                return NotFound();
            }

            _context.AdditionalProducts.Remove(additionalProduct);
            await _context.SaveChangesAsync();

            return additionalProduct;
        }

        private bool AdditionalProductExists(int id)
        {
            return _context.AdditionalProducts.Any(e => e.AdditionalId == id);
        }
    }
}
