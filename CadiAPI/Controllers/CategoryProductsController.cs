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
    public class CategoryProductsController : ControllerBase
    {
        private readonly CadiContext _context;

        public CategoryProductsController(CadiContext context)
        {
            _context = context;
        }

        // GET: api/CategoryProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> GetCategoryProducts()
        {
            return await _context.CategoryProducts.ToListAsync();
        }

        // GET: api/CategoryProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<object>>> GetCategoryProduct(int id)
        {
            var test = _context.Products.SelectMany(e => e.CategoryProducts, (e, s) =>
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
            }).Where(e => e.s.CategoryId == id);

            return await test.ToListAsync();
        }

        // PUT: api/CategoryProducts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryProduct(int id, CategoryProduct categoryProduct)
        {
            if (id != categoryProduct.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(categoryProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryProductExists(id))
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

        // POST: api/CategoryProducts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CategoryProduct>> PostCategoryProduct(CategoryProduct categoryProduct)
        {
            _context.CategoryProducts.Add(categoryProduct);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryProductExists(categoryProduct.CategoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategoryProduct", new { id = categoryProduct.CategoryId }, categoryProduct);
        }

        // DELETE: api/CategoryProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryProduct>> DeleteCategoryProduct(int id)
        {
            var categoryProduct = await _context.CategoryProducts.FindAsync(id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            _context.CategoryProducts.Remove(categoryProduct);
            await _context.SaveChangesAsync();

            return categoryProduct;
        }

        private bool CategoryProductExists(int id)
        {
            return _context.CategoryProducts.Any(e => e.CategoryId == id);
        }
    }
}
