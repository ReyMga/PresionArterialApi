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

    public async Task<bool> EliminarAsync(int id)
    {
        var medicion = await _context.Mediciones.FindAsync(id);

        if (medicion is null)
            return false;

        _context.Mediciones.Remove(medicion);
        await _context.SaveChangesAsync();

        return true;
    }
}