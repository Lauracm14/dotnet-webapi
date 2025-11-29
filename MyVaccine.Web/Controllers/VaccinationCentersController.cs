using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.Web.Data;
using MyVaccine.Web.Models;

namespace MyVaccine.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaccinationCentersController : ControllerBase
{
    private readonly MyVaccineDbContext _context;

    public VaccinationCentersController(MyVaccineDbContext context)
    {
        _context = context;
    }

    // GET: api/VaccinationCenters
    // Obtiene todos los centros de vacunación
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VaccinationCenter>>> GetVaccinationCenters()
    {
        return await _context.VaccinationCenters.ToListAsync();
    }

    // GET: api/VaccinationCenters/5
    // Obtiene un centro de vacunación por su ID
    [HttpGet("{id}")]
    public async Task<ActionResult<VaccinationCenter>> GetVaccinationCenter(int id)
    {
        var center = await _context.VaccinationCenters.FindAsync(id);

        if (center == null)
        {
            return NotFound();
        }

        return center;
    }

    // POST: api/VaccinationCenters
    // Crea un nuevo centro de vacunación
    [HttpPost]
    public async Task<ActionResult<VaccinationCenter>> PostVaccinationCenter(VaccinationCenter center)
    {
        _context.VaccinationCenters.Add(center);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVaccinationCenter", new { id = center.Id }, center);
    }

    // PUT: api/VaccinationCenters/5
    // Actualiza un centro de vacunación existente
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVaccinationCenter(int id, VaccinationCenter center)
    {
        if (id != center.Id)
        {
            return BadRequest();
        }

        _context.Entry(center).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VaccinationCenterExists(id))
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

    // DELETE: api/VaccinationCenters/5
    // Elimina un centro de vacunación
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVaccinationCenter(int id)
    {
        var center = await _context.VaccinationCenters.FindAsync(id);
        if (center == null)
        {
            return NotFound();
        }

        _context.VaccinationCenters.Remove(center);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VaccinationCenterExists(int id)
    {
        return _context.VaccinationCenters.Any(e => e.Id == id);
    }
}
