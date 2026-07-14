using Microsoft.AspNetCore.Mvc;
using PresionArterial.Api.DTOs.Mediciones;
using PresionArterial.Api.Interfaces;

namespace PresionArterial.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicionesController : ControllerBase
{
    private readonly IMedicionService _service;

    public MedicionesController(IMedicionService service)
    {
        _service = service;
    }

// GET: api/mediciones/promedios-diarios?desde=2026-07-01&hasta=2026-07-31
[HttpGet("promedios-diarios")]
public async Task<ActionResult<IEnumerable<PromedioDiarioDto>>>
    ObtenerPromediosDiarios(
        [FromQuery] DateTime desde,
        [FromQuery] DateTime hasta)
{
    if (desde > hasta)
    {
        return BadRequest(new
        {
            mensaje = "La fecha 'desde' no puede ser posterior a la fecha 'hasta'."
        });
    }

    var promedios = await _service.ObtenerPromediosDiariosAsync(
        desde,
        hasta);

    return Ok(promedios);
}

// GET: api/mediciones/promedios-franja?desde=2026-07-01&hasta=2026-07-31
[HttpGet("promedios-franja")]
public async Task<ActionResult<IEnumerable<PromedioFranjaDto>>> ObtenerPromediosPorFranja(
    [FromQuery] DateTime desde,
    [FromQuery] DateTime hasta)
{
    if (desde > hasta)
    {
        return BadRequest(new
        {
            mensaje = "La fecha 'desde' no puede ser posterior a la fecha 'hasta'."
        });
    }

    var promedios = await _service.ObtenerPromediosPorFranjaAsync(
        desde,
        hasta);

    return Ok(promedios);
}

// GET: api/mediciones
[HttpGet]
    public async Task<ActionResult<IEnumerable<MedicionDto>>> GetMediciones()
    {
        var mediciones = await _service.ObtenerTodasAsync();

        return Ok(mediciones);
    }

// GET: api/mediciones/filtrar?desde=2026-07-01&hasta=2026-07-31
[HttpGet("filtrar")]
public async Task<ActionResult<IEnumerable<MedicionDto>>> FiltrarPorFecha(
    [FromQuery] DateTime desde,
    [FromQuery] DateTime hasta)
{
    if (desde > hasta)
    {
        return BadRequest(new
        {
            mensaje = "La fecha 'desde' no puede ser posterior a la fecha 'hasta'."
        });
    }

    var mediciones = await _service.FiltrarPorFechaAsync(desde, hasta);

    return Ok(mediciones);
}

// GET: api/mediciones/estadisticas?desde=2026-07-01&hasta=2026-07-31
[HttpGet("estadisticas")]
public async Task<ActionResult<EstadisticasMedicionDto>> ObtenerEstadisticas(
    [FromQuery] DateTime desde,
    [FromQuery] DateTime hasta)
{
    if (desde > hasta)
    {
        return BadRequest(new
        {
            mensaje = "La fecha 'desde' no puede ser posterior a la fecha 'hasta'."
        });
    }

    var estadisticas = await _service.ObtenerEstadisticasAsync(desde, hasta);

    if (estadisticas is null)
    {
        return NotFound(new
        {
            mensaje = "No existen mediciones dentro del período indicado."
        });
    }

    return Ok(estadisticas);
}

// GET: api/mediciones/5
[HttpGet("{id:int}")]
    public async Task<ActionResult<MedicionDto>> GetMedicion(int id)
    {
        var medicion = await _service.ObtenerPorIdAsync(id);

        if (medicion is null)
        {
            return NotFound(new
            {
                mensaje = $"No se encontró la medición con ID {id}."
            });
        }

        return Ok(medicion);
    }

    // POST: api/mediciones
    [HttpPost]
    public async Task<ActionResult<MedicionDto>> PostMedicion(
        CrearMedicionDto dto)
    {
        var medicionCreada = await _service.CrearAsync(dto);

        return CreatedAtAction(
            nameof(GetMedicion),
            new { id = medicionCreada.Id },
            medicionCreada);
    }

// PUT: api/mediciones/5
[HttpPut("{id:int}")]
public async Task<ActionResult<MedicionDto>> PutMedicion(
    int id,
    ActualizarMedicionDto dto)
{
    var medicionActualizada = await _service.ActualizarAsync(id, dto);

    if (medicionActualizada is null)
    {
        return NotFound(new
        {
            mensaje = $"No se encontró la medición con ID {id}."
        });
    }

    return Ok(medicionActualizada);
}

// DELETE: api/mediciones/5
[HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMedicion(int id)
    {
        var eliminada = await _service.EliminarAsync(id);

        if (!eliminada)
        {
            return NotFound(new
            {
                mensaje = $"No se encontró la medición con ID {id}."
            });
        }

        return NoContent();
    }
}