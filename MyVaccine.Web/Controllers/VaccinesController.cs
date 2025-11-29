using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.Web.Data;
using MyVaccine.Web.Models;

namespace MyVaccine.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaccinesController : ControllerBase
{
    private readonly MyVaccineDbContext _context;

    public VaccinesController(MyVaccineDbContext context)
    {
        _context = context;
    }

    // GET: api/Vaccines
    // Obtiene todas las vacunas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vaccine>>> GetVaccines()
    {
        return await _context.Vaccines.ToListAsync();
    }

    // GET: api/Vaccines/5
    // Obtiene una vacuna por su ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Vaccine>> GetVaccine(int id)
    {
        var vaccine = await _context.Vaccines.FindAsync(id);

        if (vaccine == null)
        {
            return NotFound();
        }

        return vaccine;
    }

    // POST: api/Vaccines
    // Crea una nueva vacuna
    [HttpPost]
    public async Task<ActionResult<Vaccine>> PostVaccine(Vaccine vaccine)
    {
        _context.Vaccines.Add(vaccine);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVaccine", new { id = vaccine.Id }, vaccine);
    }

    // PUT: api/Vaccines/5
    // Actualiza una vacuna existente
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVaccine(int id, Vaccine vaccine)
    {
        if (id != vaccine.Id)
        {
            return BadRequest();
        }

        _context.Entry(vaccine).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VaccineExists(id))
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

    // DELETE: api/Vaccines/5
    // Elimina una vacuna
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVaccine(int id)
    {
        var vaccine = await _context.Vaccines.FindAsync(id);
        if (vaccine == null)
        {
            return NotFound();
        }

        _context.Vaccines.Remove(vaccine);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VaccineExists(int id)
    {
        return _context.Vaccines.Any(e => e.Id == id);
    }
}
