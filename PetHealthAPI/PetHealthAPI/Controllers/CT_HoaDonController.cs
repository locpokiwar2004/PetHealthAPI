using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHealthAPI.Models;

namespace PetHealthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CT_HoaDonController : ControllerBase
    {
        private readonly QLThuYContext _context;

        public CT_HoaDonController(QLThuYContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CT_HoaDon>>> GetCT_HoaDons()
        {
            return await _context.CTHoaDons.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CT_HoaDon>> GetCT_HoaDon(int id)
        {
            var ct_HoaDon = await _context.CTHoaDons.FindAsync(id);
            if (ct_HoaDon == null)
            {
                return NotFound();
            }
            return ct_HoaDon;
        }

        [HttpPost]
        public async Task<ActionResult<CT_HoaDon>> PostCT_HoaDon(CT_HoaDon ct_HoaDon)
        {
            _context.CTHoaDons.Add(ct_HoaDon);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCT_HoaDon), new { id = ct_HoaDon.ID_CTHD }, ct_HoaDon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCT_HoaDon(int id, CT_HoaDon ct_HoaDon)
        {
            if (id != ct_HoaDon.ID_CTHD)
            {
                return BadRequest();
            }

            _context.Entry(ct_HoaDon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CT_HoaDonExists(id))
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
        public async Task<IActionResult> DeleteCT_HoaDon(int id)
        {
            var ct_HoaDon = await _context.CTHoaDons.FindAsync(id);
            if (ct_HoaDon == null)
            {
                return NotFound();
            }

            _context.CTHoaDons.Remove(ct_HoaDon);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CT_HoaDonExists(int id)
        {
            return _context.CTHoaDons.Any(e => e.ID_CTHD == id);
        }
    }

}
