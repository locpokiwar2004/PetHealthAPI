using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHealthAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/KhachHang")]
[ApiController]
public class KhachHangController : ControllerBase
{
    private readonly QLThuYContext _context;

    public KhachHangController(QLThuYContext context)
    {
        _context = context;
    }

    // GET: api/KhachHang
    [HttpGet]
    public async Task<ActionResult<IEnumerable<KhachHang>>> GetKhachHangs()
    {
        return await _context.KhachHangs.ToListAsync();
    }

    // GET: api/KhachHang/5
    [HttpGet("{id}")]
    public async Task<ActionResult<KhachHang>> GetKhachHang(int id)
    {
        var khachHang = await _context.KhachHangs.FindAsync(id);

        if (khachHang == null)
        {
            return NotFound();
        }

        return khachHang;
    }

    // POST: api/KhachHang
    [HttpPost]
    public async Task<ActionResult<KhachHang>> PostKhachHang(KhachHang khachHang)
    {
        _context.KhachHangs.Add(khachHang);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetKhachHang), new { id = khachHang.MaKH }, khachHang);
    }

    // PUT: api/KhachHang/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutKhachHang(int id, KhachHang khachHang)
    {
        if (id != khachHang.MaKH)
        {
            return BadRequest();
        }

        _context.Entry(khachHang).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!KhachHangExists(id))
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

    // DELETE: api/KhachHang/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteKhachHang(int id)
    {
        var khachHang = await _context.KhachHangs.FindAsync(id);
        if (khachHang == null)
        {
            return NotFound();
        }

        _context.KhachHangs.Remove(khachHang);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool KhachHangExists(int id)
    {
        return _context.KhachHangs.Any(e => e.MaKH == id);
    }
}
