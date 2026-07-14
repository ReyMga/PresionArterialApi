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

    Task<List<MedicionDto>> FiltrarPorFechaAsync(
        DateTime desde,
        DateTime hasta
    );

    Task<EstadisticasMedicionDto?> ObtenerEstadisticasAsync(
        DateTime desde,
        DateTime hasta
    );
    Task<List<PromedioDiarioDto>> ObtenerPromediosDiariosAsync(
    DateTime desde,
    DateTime hasta
    );
    Task<List<PromedioFranjaDto>> ObtenerPromediosPorFranjaAsync(
    DateTime desde,
    DateTime hasta
    );
    
}