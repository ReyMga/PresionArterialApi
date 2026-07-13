using PresionArterial.Api.DTOs.Mediciones;

namespace PresionArterial.Api.Interfaces;

public interface IMedicionService
{
    Task<List<MedicionDto>> ObtenerTodasAsync();

    Task<MedicionDto?> ObtenerPorIdAsync(int id);

    Task<MedicionDto> CrearAsync(CrearMedicionDto dto);

    Task<MedicionDto?> ActualizarAsync(
        int id,
        ActualizarMedicionDto dto
    );

    Task<bool> EliminarAsync(int id);
}