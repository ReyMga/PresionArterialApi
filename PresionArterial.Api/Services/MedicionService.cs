using Microsoft.EntityFrameworkCore;
using PresionArterial.Api.Data;
using PresionArterial.Api.DTOs.Mediciones;
using PresionArterial.Api.Interfaces;
using PresionArterial.Api.Models;

namespace PresionArterial.Api.Services;

public class MedicionService : IMedicionService
{
    private readonly AppDbContext _context;

    public MedicionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<MedicionDto>> ObtenerTodasAsync()
    {
        return await _context.Mediciones
            .OrderBy(m => m.FechaHora)
            .Select(m => new MedicionDto
            {
                Id = m.Id,
                FechaHora = m.FechaHora,
                PresionSistolica = m.PresionSistolica,
                PresionDiastolica = m.PresionDiastolica,
                Temperatura = m.Temperatura,
                Humedad = m.Humedad,
                ValsartanMg = m.ValsartanMg,
                AtenololMg = m.AtenololMg,
                Observaciones = m.Observaciones
            })
            .ToListAsync();
    }

   public async Task<MedicionDto?> ObtenerPorIdAsync(int id)
{
    var medicion = await _context.Mediciones.FindAsync(id);

    if (medicion is null)
        return null;

    return ConvertirADto(medicion);
}
public async Task<MedicionDto> CrearAsync(CrearMedicionDto dto)
{
    var medicion = new Medicion
    {
        FechaHora = dto.FechaHora,
        PresionSistolica = dto.PresionSistolica,
        PresionDiastolica = dto.PresionDiastolica,
        Temperatura = dto.Temperatura,
        Humedad = dto.Humedad,
        ValsartanMg = dto.ValsartanMg,
        AtenololMg = dto.AtenololMg,
        Observaciones = dto.Observaciones
    };

    _context.Mediciones.Add(medicion);
    await _context.SaveChangesAsync();

    return ConvertirADto(medicion);
}
public async Task<MedicionDto?> ActualizarAsync(
    int id,
    ActualizarMedicionDto dto)
{
    var medicion = await _context.Mediciones.FindAsync(id);

    if (medicion is null)
        return null;

    medicion.FechaHora = dto.FechaHora;
    medicion.PresionSistolica = dto.PresionSistolica;
    medicion.PresionDiastolica = dto.PresionDiastolica;
    medicion.Temperatura = dto.Temperatura;
    medicion.Humedad = dto.Humedad;
    medicion.ValsartanMg = dto.ValsartanMg;
    medicion.AtenololMg = dto.AtenololMg;
    medicion.Observaciones = dto.Observaciones;

    await _context.SaveChangesAsync();

    return ConvertirADto(medicion);
}
    public async Task<List<MedicionDto>> FiltrarPorFechaAsync(
        DateTime desde,
        DateTime hasta)
    {
        return await _context.Mediciones
            .Where(m =>
                m.FechaHora >= desde &&
                m.FechaHora <= hasta)
            .OrderBy(m => m.FechaHora)
            .Select(m => new MedicionDto
            {
                Id = m.Id,
                FechaHora = m.FechaHora,
                PresionSistolica = m.PresionSistolica,
                PresionDiastolica = m.PresionDiastolica,
                Temperatura = m.Temperatura,
                Humedad = m.Humedad,
                ValsartanMg = m.ValsartanMg,
                AtenololMg = m.AtenololMg,
                Observaciones = m.Observaciones
            })
            .ToListAsync();
    }

public async Task<EstadisticasMedicionDto?> ObtenerEstadisticasAsync(
    DateTime desde,
    DateTime hasta)
{
    var consulta = _context.Mediciones
        .Where(m => m.FechaHora >= desde && m.FechaHora <= hasta);

    var cantidad = await consulta.CountAsync();

    if (cantidad == 0)
        return null;

    return new EstadisticasMedicionDto
    {
        CantidadMediciones = cantidad,

        PromedioSistolica = await consulta
            .AverageAsync(m => m.PresionSistolica),

        PromedioDiastolica = await consulta
            .AverageAsync(m => m.PresionDiastolica),

        MinimoSistolica = await consulta
            .MinAsync(m => m.PresionSistolica),

        MaximoSistolica = await consulta
            .MaxAsync(m => m.PresionSistolica),

        MinimoDiastolica = await consulta
            .MinAsync(m => m.PresionDiastolica),

        MaximoDiastolica = await consulta
            .MaxAsync(m => m.PresionDiastolica),

        PromedioTemperatura = await consulta
            .AverageAsync(m => m.Temperatura),

        PromedioHumedad = await consulta
            .AverageAsync(m => m.Humedad)
    };
}

public async Task<List<PromedioDiarioDto>> ObtenerPromediosDiariosAsync(
    DateTime desde,
    DateTime hasta)
{
    return await _context.Mediciones
        .Where(m => m.FechaHora >= desde && m.FechaHora <= hasta)
        .GroupBy(m => m.FechaHora.Date)
        .Select(grupo => new PromedioDiarioDto
        {
            Fecha = grupo.Key,
            PromedioSistolica = grupo.Average(m => m.PresionSistolica),
            PromedioDiastolica = grupo.Average(m => m.PresionDiastolica),
            CantidadMediciones = grupo.Count()
        })
        .OrderBy(resultado => resultado.Fecha)
        .ToListAsync();
}
    public async Task<bool> EliminarAsync(int id)
    {
        var medicion = await _context.Mediciones.FindAsync(id);

        if (medicion is null)
            return false;

        _context.Mediciones.Remove(medicion);
        await _context.SaveChangesAsync();

        return true;
        
    }
    private static MedicionDto ConvertirADto(Medicion medicion)
{
    return new MedicionDto
    {
        Id = medicion.Id,
        FechaHora = medicion.FechaHora,
        PresionSistolica = medicion.PresionSistolica,
        PresionDiastolica = medicion.PresionDiastolica,
        Temperatura = medicion.Temperatura,
        Humedad = medicion.Humedad,
        ValsartanMg = medicion.ValsartanMg,
        AtenololMg = medicion.AtenololMg,
        Observaciones = medicion.Observaciones
    };
}
}