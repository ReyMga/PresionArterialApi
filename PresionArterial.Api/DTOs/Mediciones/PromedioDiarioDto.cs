namespace PresionArterial.Api.DTOs.Mediciones;

public class PromedioDiarioDto
{
    public DateTime Fecha { get; set; }

    public decimal PromedioSistolica { get; set; }

    public decimal PromedioDiastolica { get; set; }

    public int CantidadMediciones { get; set; }
}