using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHealthAPI.Models;

[Route("api/ThuCung")]
[ApiController]
public class ThuCungController : ControllerBase
{
    private readonly QLThuYContext _context;

    public ThuCungController(QLThuYContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ThuCung>>> GetThuCungs()
    {
        return await _context.ThuCungs.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ThuCung>> GetThuCung(int id)
    {
        var thuCung = await _context.ThuCungs.FindAsync(id);
        if (thuCung == null)
        {
            return NotFound();
        }
        return thuCung;
    }

    [HttpPost]
    public async Task<ActionResult<ThuCung>> PostThuCung(ThuCung thuCung)
    {
        _context.ThuCungs.Add(thuCung);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetThuCung), new { id = thuCung.MaTC }, thuCung);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutThuCung(int id, ThuCung thuCung)
    {
        if (id != thuCung.MaTC)
        {
            return BadRequest();
        }

        _context.Entry(thuCung).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ThuCungExists(id))
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
    public async Task<IActionResult> DeleteThuCung(int id)
    {
        var thuCung = await _context.ThuCungs.FindAsync(id);
        if (thuCung == null)
        {
            return NotFound();
        }

        _context.ThuCungs.Remove(thuCung);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool ThuCungExists(int id)
    {
        return _context.ThuCungs.Any(e => e.MaTC == id);
    }
}
