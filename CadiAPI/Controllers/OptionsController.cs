﻿using System;
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
    public class OptionsController : ControllerBase
    {
        private readonly CadiContext _context;

        public OptionsController(CadiContext context)
        {
            _context = context;
        }

        // GET: api/Options
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Options>>> GetOptions()
        {
            return await _context.Options.ToListAsync();
        }

        // GET: api/Options/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<object>>> GetOptions(int id)
        {
            var teste2 = _context.Products.Where(c => c.Id == id).Select(d => d.Value).FirstOrDefault();

            var teste = _context.Options.SelectMany(e => e.OptionsProducts, (e, s) =>
            new { e.Description, e.Value , s }).Where(e => e.s.ProductId == id);

            return await teste.ToListAsync();
        }

        // PUT: api/Options/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOptions(int id, Options options)
        {
            if (id != options.Id)
            {
                return BadRequest();
            }

            _context.Entry(options).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionsExists(id))
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

        // POST: api/Options
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Options>> PostOptions(Options options)
        {
            _context.Options.Add(options);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOptions", new { id = options.Id }, options);
        }

        // DELETE: api/Options/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Options>> DeleteOptions(int id)
        {
            var options = await _context.Options.FindAsync(id);
            if (options == null)
            {
                return NotFound();
            }

            _context.Options.Remove(options);
            await _context.SaveChangesAsync();

            return options;
        }

        private bool OptionsExists(int id)
        {
            return _context.Options.Any(e => e.Id == id);
        }
    }
}
