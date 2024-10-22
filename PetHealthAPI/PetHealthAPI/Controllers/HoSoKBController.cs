using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHealthAPI.Models;

namespace PetHealthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoSoKBController : ControllerBase
    {
        private readonly QLThuYContext _context;

        public HoSoKBController(QLThuYContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoSoKB>>> GetHoSoKBs()
        {
            return await _context.HoSoKBs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HoSoKB>> GetHoSoKB(int id)
        {
            var hoSoKB = await _context.HoSoKBs.FindAsync(id);
            if (hoSoKB == null)
            {
                return NotFound();
            }
            return hoSoKB;
        }

        [HttpPost]
        public async Task<ActionResult<HoSoKB>> PostHoSoKB(HoSoKB hoSoKB)
        {
            _context.HoSoKBs.Add(hoSoKB);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHoSoKB), new { id = hoSoKB.MaHS }, hoSoKB);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoSoKB(int id, HoSoKB hoSoKB)
        {
            if (id != hoSoKB.MaHS)
            {
                return BadRequest();
            }

            _context.Entry(hoSoKB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoSoKBExists(id))
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
        public async Task<IActionResult> DeleteHoSoKB(int id)
        {
            var hoSoKB = await _context.HoSoKBs.FindAsync(id);
            if (hoSoKB == null)
            {
                return NotFound();
            }

            _context.HoSoKBs.Remove(hoSoKB);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool HoSoKBExists(int id)
        {
            return _context.HoSoKBs.Any(e => e.MaHS == id);
        }
    }

}
