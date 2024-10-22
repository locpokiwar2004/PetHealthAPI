using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHealthAPI.Models;

namespace PetHealthAPI.Controllers
{
    [Route("api/Thuoc")]
    [ApiController]
    public class ThuocController : ControllerBase
    {
        private readonly QLThuYContext _context;

        public ThuocController(QLThuYContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thuoc>>> GetThuocs()
        {
            return await _context.Thuocs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Thuoc>> GetThuoc(int id)
        {
            var thuoc = await _context.Thuocs.FindAsync(id);
            if (thuoc == null)
            {
                return NotFound();
            }
            return thuoc;
        }

        [HttpPost]
        public async Task<ActionResult<Thuoc>> PostThuoc(Thuoc thuoc)
        {
            _context.Thuocs.Add(thuoc);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetThuoc), new { id = thuoc.MaThuoc }, thuoc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutThuoc(int id, Thuoc thuoc)
        {
            if (id != thuoc.MaThuoc)
            {
                return BadRequest();
            }

            _context.Entry(thuoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuocExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThuoc(int id)
        {
            var thuoc = await _context.Thuocs.FindAsync(id);
            if (thuoc == null)
            {
                return NotFound();
            }

            _context.Thuocs.Remove(thuoc);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ThuocExists(int id)
        {
            return _context.Thuocs.Any(e => e.MaThuoc == id);
        }
    }

}
