using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API___Modelo_1.Models;

namespace WEB_API___Modelo_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly Contexto _contexto;

        public ItemsController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _contexto.Items.ToArrayAsync();
        }

        // GET: api/Items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(long id)
        {
            var Item = await _contexto.Items.FindAsync(id);

            if (Item == null)
            {
                return NotFound();
            }

            return Item;
        }

        // PUT: api/Items/{id}
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(long id, Item Item)
        {
            if (id != Item.Id)
            {
                return BadRequest();
            }

            _contexto.Entry(Item).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item Item)
        {
            
            _contexto.Items.Add(Item);
            await _contexto.SaveChangesAsync();

            //return CreatedAtAction("GetItem", new { id = Item.Id }, Item);
            return CreatedAtAction(nameof(GetItem), new { id = Item.Id }, Item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(long id)
        {
            var Item = await _contexto.Items.FindAsync(id);
            if (Item == null)
            {
                return NotFound();
            }

            _contexto.Items.Remove(Item);
            await _contexto.SaveChangesAsync();

            return Item;
        }

        private bool ItemExists(long id)
        {
            return _contexto.Items.Any(e => e.Id == id);
        }
    }
}
