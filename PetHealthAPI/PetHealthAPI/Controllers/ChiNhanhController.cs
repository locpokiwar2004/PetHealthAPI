using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHealthAPI.Models;

namespace PetHealthAPI.Controllers
{
    [Route("api/ChiNhanh")]
    [ApiController]
    public class ChiNhanhController : ControllerBase
    {
        private readonly QLThuYContext _context;

        public ChiNhanhController(QLThuYContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiNhanh>>> GetChiNhanhs()
        {
            return await _context.ChiNhanhs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChiNhanh>> GetChiNhanh(int id)
        {
            var chiNhanh = await _context.ChiNhanhs.FindAsync(id);
            if (chiNhanh == null)
            {
                return NotFound();
            }
            return chiNhanh;
        }

        [HttpPost]
        public async Task<ActionResult<ChiNhanh>> PostChiNhanh(ChiNhanh chiNhanh)
        {
            _context.ChiNhanhs.Add(chiNhanh);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetChiNhanh), new { id = chiNhanh.MaCN }, chiNhanh);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiNhanh(int id, ChiNhanh chiNhanh)
        {
            if (id != chiNhanh.MaCN)
            {
                return BadRequest();
            }

            _context.Entry(chiNhanh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiNhanhExists(id))
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
        public async Task<IActionResult> DeleteChiNhanh(int id)
        {
            var chiNhanh = await _context.ChiNhanhs.FindAsync(id);
            if (chiNhanh == null)
            {
                return NotFound();
            }

            _context.ChiNhanhs.Remove(chiNhanh);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ChiNhanhExists(int id)
        {
            return _context.ChiNhanhs.Any(e => e.MaCN == id);
        }
    }

}
