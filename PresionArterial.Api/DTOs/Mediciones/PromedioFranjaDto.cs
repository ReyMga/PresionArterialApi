namespace PresionArterial.Api.DTOs.Mediciones;

public class PromedioFranjaDto
{
    public string Franja { get; set; } = string.Empty;

    public decimal PromedioSistolica { get; set; }

    public decimal PromedioDiastolica { get; set; }

    public int CantidadMediciones { get; set; }
}