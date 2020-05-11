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
    public class OrdersController : ControllerBase
    {
        private readonly CadiContext _context;

        public OrdersController(CadiContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{type}/{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder(string type, int? id)
        {
            List<Order> orders = new List<Order>();

            if(type == "table")
            {
                orders = await _context.Orders.Where(c => c.TableId == id && c.OrderStatus == 2).ToListAsync();

                if (orders == null)
                {
                    return NotFound();
                }
            }
            if(type == "order")
            {
                orders = await _context.Orders.Where(c => c.OrderId == id).ToListAsync();

                if (orders == null)
                {
                    return NotFound();
                }
            }

            return orders;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int? id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder([FromBody]Order order)
        {
            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

            }catch(Exception ex)
            {
                string msg = ex.Message;
            }

            return Ok(order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int? id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int? id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
